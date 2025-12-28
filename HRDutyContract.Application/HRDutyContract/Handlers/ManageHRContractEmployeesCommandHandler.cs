using AutoMapper;
using HRDutyContract.Application.Common.Interfaces;
using HRDutyContract.Application.Common.ViewModels;
using HRDutyContract.Application.HRDutyContract.Commands;
using HRDutyContract.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRDutyContract.Application.HRDutyContract.Handlers
{
    public class ManageHRContractEmployeesCommandHandler
       : IRequestHandler<ManageHRContractEmployeesCommand, AbstractViewModel>
    {
        private readonly IHRContext _context;
        private readonly IMapper _mapper;

        public ManageHRContractEmployeesCommandHandler(IHRContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AbstractViewModel> Handle(ManageHRContractEmployeesCommand request, CancellationToken cancellationToken)
        {
            var result = new AbstractViewModel();

            // DELETE 
            if (request.IsDelete)
            {
                var entity = await _context.HRContractEmployees
                    .FirstOrDefaultAsync(x =>
                        x.DetailsID == request.Employee.DetailsID &&
                        x.ContractID == request.Employee.ContractID &&
                        x.CompanyID == request.Employee.CompanyID,
                        cancellationToken);

                if (entity == null)
                {
                    result.lstError.Add("Record not found");
                    return result;
                }

                entity.RecordDeleted = true;
                entity.IsActive = false;

                await _context.SaveChangesAsync(cancellationToken);

                result.status = true;
                result.EntityId = entity.DetailsID;
                return result;
            }

            // CREATE
            if (request.Employee.DetailsID == 0)
            {
                var entity = _mapper.Map<HRContractEmployees>(request.Employee);

                entity.RecordDateEntry = DateTime.Now;
                entity.RecordDeleted = false;

                await _context.HRContractEmployees.AddAsync(entity, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                result.status = true;
                result.EntityId = entity.DetailsID;
                return result;
            }

            //UPDATE
            var existing = await _context.HRContractEmployees
                .FirstOrDefaultAsync(x =>
                    x.DetailsID == request.Employee.DetailsID &&
                    x.ContractID == request.Employee.ContractID &&
                    x.CompanyID == request.Employee.CompanyID,
                    cancellationToken);

            if (existing == null)
            {
                result.lstError.Add("Record not found");
                return result;
            }

            _mapper.Map(request.Employee, existing);

            await _context.SaveChangesAsync(cancellationToken);

            result.status = true;
            result.EntityId = existing.DetailsID;
            return result;
        }
    }

}
