using AutoMapper;
using HRDutyContract.Application.Common.Interfaces;
using HRDutyContract.Application.Common.ViewModels;
using HRDutyContract.Application.HRDutyContract.Commands;
using HRDutyContract.Application.HRDutyContract.Queries;
using HRDutyContract.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRDutyContract.Application.HRDutyContract.Handlers
{
    public class ManageHRContractDepartmentsCommandHandler
        : IRequestHandler<ManageHRContractDepartmentsCommand, AbstractViewModel>
    {
        private readonly IHRContext _context;
        private readonly IMapper _mapper;

        public ManageHRContractDepartmentsCommandHandler(IHRContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AbstractViewModel> Handle(
            ManageHRContractDepartmentsCommand request,
            CancellationToken cancellationToken)
        {
            var response = new AbstractViewModel();
            response.lstResult = new List<AbstractViewModel>();

            foreach (var item in request.Departments)
            {
                var singleResult = new AbstractViewModel();

                try
                {
                    if (item.Department == null)
                    {
                        singleResult.lstError.Add("Department object cannot be null.");
                        response.lstResult.Add(singleResult);
                        continue;
                    }

                    if (item.Department.DepartmentID == 0)
                        item.Department.DepartmentID = null;

                    var existing = await _context.HRContractDepartments
                        .FirstOrDefaultAsync(x =>
                            x.DetailsID == item.Department.DetailsID &&
                            x.ContractID == item.Department.ContractID &&
                            x.CompanyID == item.Department.CompanyID,
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
                        _mapper.Map(item.Department, existing);
                        await _context.SaveChangesAsync(cancellationToken);

                        singleResult.status = true;
                        singleResult.EntityId = existing.DetailsID;
                    }
                    // CREATE
                    else
                    {
                        item.Department.RecordDeleted = false;
                        item.Department.RecordDateEntry = DateTime.Now;
                        item.Department.IsActive ??= true;

                        await _context.HRContractDepartments.AddAsync(item.Department, cancellationToken);
                        await _context.SaveChangesAsync(cancellationToken);

                        singleResult.status = true;
                        singleResult.EntityId = item.Department.DetailsID;
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