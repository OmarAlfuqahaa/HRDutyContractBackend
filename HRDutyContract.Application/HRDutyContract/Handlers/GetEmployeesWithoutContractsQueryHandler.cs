using HRDutyContract.Application.Common.Interfaces;
using HRDutyContract.Application.HRDutyContract.Queries;
using HRDutyContract.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace HRDutyContract.Application.HRDutyContract.Handlers
{
    public class GetEmployeesWithoutContractsQueryHandler
        : IRequestHandler<GetEmployeesWithoutContractsQuery, List<Users>>
    {
        private readonly IHRContext _context;

        public GetEmployeesWithoutContractsQueryHandler(IHRContext context)
        {
            _context = context;
        }

        public async Task<List<Users>> Handle(GetEmployeesWithoutContractsQuery request, CancellationToken cancellationToken)
        {
            var employeesWithoutContracts = await _context.Users
                .Where(u => u.ContractID == null)
                .ToListAsync(cancellationToken);

            return employeesWithoutContracts;
        }
    }
}
