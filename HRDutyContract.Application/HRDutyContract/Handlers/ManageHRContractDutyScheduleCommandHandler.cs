using HRDutyContract.Application.Common.Interfaces;
using HRDutyContract.Domain.Entities;
using MediatR;
using HRDutyContract.Application.HRDutyContract.Commands;
using Microsoft.EntityFrameworkCore;
using HRDutyContract.Application.Common.ViewModels;
using HRDutyContract.Application.Common.Services;


namespace HRDutyContract.Application.HRDutyContract.Handlers
{
    public class ManageHRContractDutyScheduleCommandHandler : IRequestHandler<ManageHRContractDutyScheduleCommand, AbstractViewModel>
    {
        private readonly IHRContext _context;

        public ManageHRContractDutyScheduleCommandHandler(IHRContext context)
        {
            _context = context;
        }

        public async Task<AbstractViewModel> Handle(ManageHRContractDutyScheduleCommand request, CancellationToken cancellationToken)
        {
            var vm = new AbstractViewModel();
            var entity = request.Schedule ?? throw new ArgumentNullException(nameof(request.Schedule));

            // DELETE 
            if (request.IsDelete)
            {
                if (entity.DetailsID == 0)
                {
                    vm.lstError.Add("Cannot delete a record with DetailsID = 0.");
                    return vm;
                }

                var existing = await _context.HRContractDutySchedules
                    .FirstOrDefaultAsync(x => x.DetailsID == entity.DetailsID, cancellationToken);

                if (existing == null)
                {
                    vm.lstError.Add($"Record with DetailsID = {entity.DetailsID} does not exist!");
                    return vm;
                }

                existing.RecordDeleted = true;
                existing.IsActive = false;

                await _context.SaveChangesAsync(cancellationToken);

                vm.EntityId = existing.DetailsID;
                vm.status = true;
                return vm;
            }

            // CREATE 
            if (entity.DetailsID == 0)
            {
                entity.RecordDateEntry = DateTime.Now;
                entity.IsActive ??= true;
                entity.RecordDeleted = false;

                _context.HRContractDutySchedules.Add(entity);
                await _context.SaveChangesAsync(cancellationToken);

                vm.EntityId = entity.DetailsID; 
                vm.status = true;
                return vm;
            }

            // UPDATE 
            var existingUpdate = await _context.HRContractDutySchedules
                .FirstOrDefaultAsync(x => x.DetailsID == entity.DetailsID, cancellationToken);

            if (existingUpdate == null)
            {
                vm.lstError.Add($"Record with DetailsID = {entity.DetailsID} does not exist, cannot update.");
                return vm;
            }

            var updater = new UpdaterManager<HRContractDutySchedule>();
            updater.getUpdatedEntityBasedNewEntityWithNullsUpdate(existingUpdate, entity, typeof(ManageHRContractDutyScheduleCommand));

            await _context.SaveChangesAsync(cancellationToken);

            vm.EntityId = existingUpdate.DetailsID;
            vm.status = true;
            return vm;
        }
    }
}