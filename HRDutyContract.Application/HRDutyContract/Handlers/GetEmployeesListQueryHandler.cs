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

        public async Task<GELQ_Response> Handle(GetEmployeesListQuery request, CancellationToken cancellationToken)
        {
            var query = _context.HRContractEmployees.AsQueryable();

            if (request.Filters != null && request.Filters.Any())
            {
                foreach (var filter in request.Filters)
                {
                    if (filter.Field.Equals("IsActive", StringComparison.OrdinalIgnoreCase)
                        && bool.TryParse(filter.Value, out var isActive))
                    {
                        query = query.Where(x => x.IsActive == isActive);
                    }

                    if (filter.Field.Equals("ContractID", StringComparison.OrdinalIgnoreCase)
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