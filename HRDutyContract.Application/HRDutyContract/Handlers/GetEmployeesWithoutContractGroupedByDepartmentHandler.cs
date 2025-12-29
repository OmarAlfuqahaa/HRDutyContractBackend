using HRDutyContract.Application.Common.Interfaces;
using HRDutyContract.Application.Common.ViewModels;
using HRDutyContract.Application.HRDutyContract.Queries;
using HRDutyContract.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRDutyContract.Application.HRDutyContract.Handlers
{
    public class GetEmployeesWithoutContractGroupedByDepartmentQueryHandler
    : IRequestHandler<GetEmployeesWithoutContractGroupedByDepartmentQuery, Dictionary<int?, List<Users>>>
    {
        private readonly IHRContext _context;

        public GetEmployeesWithoutContractGroupedByDepartmentQueryHandler(IHRContext context)
        {
            _context = context;
        }

        public async Task<Dictionary<int?, List<Users>>> Handle(
            GetEmployeesWithoutContractGroupedByDepartmentQuery request,
            CancellationToken cancellationToken)
        {
            var employees = await _context.Users
                .Where(u => u.ContractID == null)
                .ToListAsync(cancellationToken);

            var grouped = employees
                .GroupBy(e => e.DepartmentID)
                .ToDictionary(g => g.Key, g => g.ToList());

            return grouped;
        }
    }
}
