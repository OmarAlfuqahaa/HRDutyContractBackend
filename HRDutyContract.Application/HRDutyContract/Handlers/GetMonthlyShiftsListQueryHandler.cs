using HRDutyContract.Application.Common.Interfaces;
using HRDutyContract.Application.HRDutyContract.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace HRDutyContract.Application.HRDutyContract.Handlers
{
    public class GetMonthlyShiftsListQueryHandler
        : IRequestHandler<GetMonthlyShiftsListQuery, GMLQ_Response>
    {
        private readonly IHRContext _context;

        public GetMonthlyShiftsListQueryHandler(IHRContext context)
        {
            _context = context;
        }

        public async Task<GMLQ_Response> Handle(
                GetMonthlyShiftsListQuery request,
                CancellationToken cancellationToken)
        {
            var query = _context.HRContractMonthlyShifts
                .AsNoTracking()
                .AsQueryable();

            // Filters
            if (request.IsActive.HasValue)
                query = query.Where(x => x.IsActive == request.IsActive.Value);

            if (request.ContractId.HasValue)
                query = query.Where(x => x.ContractID == request.ContractId.Value);

            // Count
            var rowsCount = await query.CountAsync(cancellationToken);

            // Order
            query = query.OrderBy(x => x.DetailsID);

            // Pagination
            if (request.PageSize != -1)
            {
                query = query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize);
            }

            // Projection
            var data = await query
                .Select(x => new GMLQ_HRContractMonthlyShift
                {
                    DetailsID = x.DetailsID,
                    ContractID = x.ContractID,
                    CompanyID = x.CompanyID,
                    Month = x.Month,
                    Year = x.Year,
                    TotalShifts = x.TotalShifts,
                    TotalHours = x.TotalHours,
                    IsActive = x.IsActive,
                    Note = x.Note
                })
                .ToListAsync(cancellationToken);

            return new GMLQ_Response
            {
                LstData = data,
                RowsCount = rowsCount
            };
        }

    }
}
