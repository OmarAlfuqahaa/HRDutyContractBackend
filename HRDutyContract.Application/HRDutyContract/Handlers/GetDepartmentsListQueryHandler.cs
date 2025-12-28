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

        public async Task<GDLQ_Response> Handle(GetDepartmentsListQuery request, CancellationToken cancellationToken)
        {
            var query = _context.HRContractDepartments.AsQueryable();

            if (request.Filters != null && request.Filters.Any())
            {
                foreach (var filter in request.Filters)
                {
                    if (filter.Field.Equals("IsActive", System.StringComparison.OrdinalIgnoreCase)
                        && bool.TryParse(filter.Value, out var isActive))
                    {
                        query = query.Where(x => x.IsActive == isActive);
                    }

                    if (filter.Field.Equals("ContractID", System.StringComparison.OrdinalIgnoreCase)
                         && int.TryParse(filter.Value, out var contractId))
                    {
                        query = query.Where(x => x.ContractID == contractId);
                    }
                }
            }

            query = query.Where(x => x.RecordDeleted != true);

            query = query.OrderBy(x => x.DetailsID);

            var rowsCount = await query.CountAsync(cancellationToken);

            var data = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
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
