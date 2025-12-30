using AutoMapper;
using AutoMapper.QueryableExtensions;
using HRDutyContract.Application.Common.Interfaces;
using HRDutyContract.Application.HRDutyContract.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRDutyContract.Application.HRDutyContract.Handlers
{
    public class GetDepartmentsListQueryHandler : IRequestHandler<GetDepartmentsListQuery, GDLQ_Response>
    {
        private readonly IHRContext _context;
        private readonly IMapper _mapper;

        public GetDepartmentsListQueryHandler(IHRContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GDLQ_Response> Handle(
                GetDepartmentsListQuery request,
                CancellationToken cancellationToken)
        {
            var query = _context.HRContractDepartments
                .AsNoTracking()
                .Where(x => x.RecordDeleted != true)
                .AsQueryable();

            // Filters
            if (request.IsActive.HasValue)
            {
                query = query.Where(x => x.IsActive == request.IsActive.Value);
            }

            if (request.ContractId.HasValue)
            {
                query = query.Where(x => x.ContractID == request.ContractId.Value);
            }

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
                .ProjectTo<GDLQ_HRContractDepartment>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new GDLQ_Response
            {
                LstData = data,
                RowsCount = rowsCount
            };
        }

    }
}
