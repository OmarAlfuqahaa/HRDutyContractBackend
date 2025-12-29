using HRDutyContract.Application.Common.Interfaces;
using HRDutyContract.Application.Common.ViewModels;
using HRDutyContract.Application.HRDutyContract.Queries;
using HRDutyContract.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace HRDutyContract.Application.HRDutyContract.Handlers
{
    public class GetEmployeesWithoutContractsQueryHandler
    : IRequestHandler<GetEmployeesWithoutContractsQuery, GEWC_Response>
    {
        private readonly IHRContext _context;

        public GetEmployeesWithoutContractsQueryHandler(IHRContext context)
        {
            _context = context;
        }

        public async Task<GEWC_Response> Handle(GetEmployeesWithoutContractsQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Users.AsQueryable();

            if (request.CompanyId.HasValue)
                query = query.Where(u => u.CompanyID == request.CompanyId.Value);

            query = query.Where(u => u.ContractID == null);

            var list = await query
                .Select(u => new GEWC_User
                {
                    UserName = u.UserName,
                    AccArName = u.AccArName
                })
                .ToListAsync(cancellationToken);

            return new GEWC_Response
            {
                LstData = list,
                RowsCount = list.Count
            };
        }
    }

}
