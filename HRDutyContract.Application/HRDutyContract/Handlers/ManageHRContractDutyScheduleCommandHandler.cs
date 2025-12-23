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

            // DELETE
            if (request.IsDelete)
            {
                if (request.DetailsID <= 0)
                {
                    vm.lstError.Add("Cannot delete a record with invalid DetailsID.");
                    return vm;
                }

                var existingDelete = await _context.HRContractDutySchedules
                    .FirstOrDefaultAsync(x => x.DetailsID == request.DetailsID, cancellationToken);

                if (existingDelete == null)
                {
                    vm.lstError.Add($"Record with DetailsID = {request.DetailsID} does not exist.");
                    return vm;
                }

                existingDelete.RecordDeleted = true;
                existingDelete.IsActive = false;

                await _context.SaveChangesAsync(cancellationToken);

                vm.EntityId = existingDelete.DetailsID;
                vm.status = true;
                return vm;
            }

            // CREATE
            if (request.DetailsID == 0)
            {
                var newEntity = new HRContractDutySchedule
                {
                    ContractID = request.ContractID,
                    ShiftTypeID = request.ShiftTypeID,
                    FromTime = request.FromTime,
                    ToTime = request.ToTime,
                    Note = request.Note,
                    IsActive = request.IsActive ?? true,
                    RecordDeleted = false,
                    RecordDateEntry = DateTime.Now
                };

                _context.HRContractDutySchedules.Add(newEntity);
                await _context.SaveChangesAsync(cancellationToken);

                vm.EntityId = newEntity.DetailsID;
                vm.status = true;
                return vm;
            }

            // UPDATE
            var existingUpdate = await _context.HRContractDutySchedules
                .FirstOrDefaultAsync(x => x.DetailsID == request.DetailsID, cancellationToken);

            if (existingUpdate == null)
            {
                vm.lstError.Add($"Record with DetailsID = {request.DetailsID} does not exist, cannot update.");
                return vm;
            }

            existingUpdate.ContractID = request.ContractID != 0 ? request.ContractID : existingUpdate.ContractID;
            existingUpdate.ShiftTypeID = request.ShiftTypeID != 0 ? request.ShiftTypeID : existingUpdate.ShiftTypeID;
            existingUpdate.FromTime = request.FromTime ?? existingUpdate.FromTime;
            existingUpdate.ToTime = request.ToTime ?? existingUpdate.ToTime;
            existingUpdate.Note = request.Note ?? existingUpdate.Note;
            if (request.IsActive.HasValue)
                existingUpdate.IsActive = request.IsActive.Value;

            await _context.SaveChangesAsync(cancellationToken);

            vm.EntityId = existingUpdate.DetailsID;
            vm.status = true;
            return vm;
        }
    }
}
