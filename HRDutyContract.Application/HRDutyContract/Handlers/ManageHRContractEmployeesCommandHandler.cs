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
            var response = new AbstractViewModel();

            response.lstResult = new List<AbstractViewModel>();

            foreach (var item in request.Employees)
            {
                var singleResult = new AbstractViewModel();

                try
                {
                    if (item.Employee == null)
                    {
                        singleResult.lstError.Add("Employee object cannot be null.");
                        response.lstResult.Add(singleResult);
                        continue;
                    }

                    var existing = await _context.HRContractEmployees
                        .FirstOrDefaultAsync(x =>
                            x.DetailsID == item.Employee.DetailsID &&
                            x.ContractID == item.Employee.ContractID &&
                            x.CompanyID == item.Employee.CompanyID,
                            cancellationToken);

                    // DELETE
                    if (item.IsDelete)
                    {
                        if (existing == null)
                        {
                            singleResult.lstError.Add("Record not found for deletion.");
                        }
                        else
                        {
                            existing.RecordDeleted = true;
                            existing.IsActive = false;
                            await _context.SaveChangesAsync(cancellationToken);

                            singleResult.status = true;
                            singleResult.EntityId = existing.DetailsID;
                        }

                        response.lstResult.Add(singleResult);
                        continue;
                    }

                    // UPDATE
                    if (existing != null)
                    {
                        _mapper.Map(item.Employee, existing);
                        await _context.SaveChangesAsync(cancellationToken);

                        singleResult.status = true;
                        singleResult.EntityId = existing.DetailsID;
                    }
                    // CREATE
                    else
                    {
                        item.Employee.RecordDeleted = false;
                        item.Employee.RecordDateEntry = DateTime.Now;
                        await _context.HRContractEmployees.AddAsync(item.Employee, cancellationToken);
                        await _context.SaveChangesAsync(cancellationToken);

                        singleResult.status = true;
                        singleResult.EntityId = item.Employee.DetailsID;
                    }
                }
                catch (Exception ex)
                {
                    singleResult.lstError.Add(ex.Message);
                }

                response.lstResult.Add(singleResult);
            }

            response.status = true;
            return response;
        }
    }

}
