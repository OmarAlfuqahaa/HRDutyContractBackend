using AutoMapper;
using HRDutyContract.Application.Common.Interfaces;
using HRDutyContract.Application.HRDutyContract.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace HRDutyContract.Application.HRDutyContract.Handlers
{
    public class GetHRContractDutyScheduleListQueryHandler : IRequestHandler<GetHRContractDutyScheduleListQuery, HRCDS_ListResponse>
    {
        private readonly IHRContext _context;
        private readonly IMapper _mapper;

        public GetHRContractDutyScheduleListQueryHandler(IHRContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<HRCDS_ListResponse> Handle(
            GetHRContractDutyScheduleListQuery request,
            CancellationToken cancellationToken)
        {
            var query = _context.HRContractDutySchedules
                .AsNoTracking()
                .AsQueryable();

            // Filters
            if (request.ContractID.HasValue)
                query = query.Where(x => x.ContractID == request.ContractID.Value);

            if (request.IsActive.HasValue)
                query = query.Where(x => x.IsActive == request.IsActive.Value);

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
            var data = await _mapper.ProjectTo<HRCDS_Response>(
                    query,
                    _mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new HRCDS_ListResponse
            {
                LstData = data,
                RowsCount = rowsCount
            };
        }

    }

}
