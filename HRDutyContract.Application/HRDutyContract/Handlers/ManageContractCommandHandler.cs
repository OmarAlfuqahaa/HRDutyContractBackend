using MediatR;
using HRDutyContract.Application.Common.Interfaces;
using HRDutyContract.Application.Common.ViewModels;
using HRDutyContract.Domain.Entities;
using AutoMapper;
using HRDutyContract.Application.HRDutyContract.Commands;
using HRDutyContract.Application.Common.Services;

namespace HRDutyContract.Application.HRDutyContract.Handlers
{
    public class ManageContractCommandHandler : IRequestHandler<ManageContractCommand, AbstractViewModel>
    {
        private readonly IHRContext _context;
        private readonly IMapper _mapper;

        public ManageContractCommandHandler(IHRContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AbstractViewModel> Handle(ManageContractCommand request, CancellationToken cancellationToken)
        {
            var vm = new AbstractViewModel();
            var contract = request.Contract;

            var newEntity = _mapper.Map<HRContract>(contract);

            if (contract.ContractID == 0)
            {
                int newId = 1;
                if (_context.HRContracts.Any())
                    newId = _context.HRContracts.Max(c => c.ContractID) + 1;

                contract.ContractID = newId;
                newEntity.ContractID = newId;
                contract.CompanyID = 1;

                newEntity.IsActive ??= true;
                newEntity.RecordDeleted = false; 
                newEntity.RecordDateEntry = DateTime.Now;

                await _context.HRContracts.AddAsync(newEntity, cancellationToken);
            }
            else
            {
                var existing = await _context.HRContracts
                    .FindAsync(new object[] { contract.ContractID, contract.CompanyID }, cancellationToken);

                if (existing == null)
                {
                    vm.lstError.Add("Contract not found!");
                    return vm;
                }

                if (request.IsDelete)
                {
                    existing.IsActive = false;
                    existing.RecordDeleted = true;
                    contract.CompanyID = 1;


                }
                else
                {
                    var updater = new UpdaterManager<HRContract>();
                    updater.getUpdatedEntityBasedNewEntityWithNullsUpdate(
                        existing,
                        newEntity,
                        typeof(ManageContractCommand));

                    existing.RecordDeleted = false;
                    existing.IsActive = true;
                    contract.CompanyID = 1;

                }

            }

            await _context.SaveChangesAsync(cancellationToken);

            vm.EntityId = newEntity.ContractID;
            vm.status = true;

            return vm;
        }
    }
}
