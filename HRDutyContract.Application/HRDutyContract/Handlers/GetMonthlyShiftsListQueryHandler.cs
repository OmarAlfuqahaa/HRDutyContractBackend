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
            var query = _context.HRContractMonthlyShifts.AsQueryable();



            var rowsCount = await query.CountAsync(cancellationToken);

            var data = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
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
