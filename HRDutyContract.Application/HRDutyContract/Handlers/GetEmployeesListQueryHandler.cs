using AutoMapper;
using AutoMapper.QueryableExtensions;
using HRDutyContract.Application.Common.Interfaces;
using HRDutyContract.Application.HRDutyContract.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace HRDutyContract.Application.HRDutyContract.Handlers
{
    public class GetEmployeesListQueryHandler : IRequestHandler<GetEmployeesListQuery, GELQ_Response>
    {
        private readonly IHRContext _context;
        private readonly IMapper _mapper;

        public GetEmployeesListQueryHandler(IHRContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GELQ_Response> Handle(
                GetEmployeesListQuery request,
                CancellationToken cancellationToken)
        {
            var query = _context.HRContractEmployees
                .AsNoTracking()
                .Where(x => x.RecordDeleted != true)
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
                .ProjectTo<GELQ_HRContractEmployees>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new GELQ_Response
            {
                LstData = data,
                RowsCount = rowsCount
            };
        }

    }
}