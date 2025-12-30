using HRDutyContract.Application.Common.Interfaces;
using HRDutyContract.Application.HRDutyContract.Queries;
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

        public async Task<GEWC_Response> Handle(
            GetEmployeesWithoutContractsQuery request,
            CancellationToken cancellationToken)
        {
            var query = _context.Users
                .Where(u => u.ContractID == null);

            if (request.CompanyId.HasValue)
            {
                query = query.Where(u => u.CompanyID == request.CompanyId.Value);
            }

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var search = request.SearchTerm.Trim().ToLower();

                query = query.Where(u =>
                    (u.AccArName != null && u.AccArName.ToLower().Contains(search)) ||
                    (u.AccEnName != null && u.AccEnName.ToLower().Contains(search)) ||
                    (u.UserName != null && u.UserName.ToLower().Contains(search)) ||
                    (u.DepartmentArName != null && u.DepartmentArName.ToLower().Contains(search)) ||
                    (u.DepartmentEnName != null && u.DepartmentEnName.ToLower().Contains(search))
                );
            }

            var data = await query
                .GroupBy(u => new
                {
                    u.DepartmentID,
                    u.DepartmentArName
                })
                .Select(g => new GEWC_DepartmentGroup
                {
                    DepartmentID = g.Key.DepartmentID,
                    DepartmentArName = g.Key.DepartmentArName ?? "بدون قسم",
                    Users = g.Select(u => new GEWC_User
                    {
                        UserName = u.UserName,
                        AccArName = u.AccArName
                    })
                    .OrderBy(u => u.AccArName)
                    .ToList()
                })
                .OrderBy(g => g.DepartmentArName)
                .ToListAsync(cancellationToken);

            return new GEWC_Response
            {
                LstData = data,
                RowsCount = data.Sum(d => d.Users.Count)
            };
        }
    }


}
