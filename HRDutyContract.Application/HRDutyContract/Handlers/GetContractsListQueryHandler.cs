using AutoMapper;
using HRDutyContract.Application.Common.Interfaces;
using HRDutyContract.Application.HRDutyContract.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRDutyContract.Application.HRDutyContract.Handlers
{
    public class GetContractsListQueryHandler : IRequestHandler<GetContractsListQuery, GCLQ_Response>
    {
        private readonly IHRContext _context;
        private readonly IMapper _mapper;

        public GetContractsListQueryHandler(IHRContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GCLQ_Response> Handle(GetContractsListQuery request, CancellationToken cancellationToken)
        {
            return await Execute(request, cancellationToken);
        }

        private async Task<GCLQ_Response> Execute(GetContractsListQuery request, CancellationToken cancellationToken)
        {
            var response = new GCLQ_Response();

            var query = _context.HRContracts.AsQueryable();

            if (request.Filters != null && request.Filters.Any())
            {
                foreach (var filter in request.Filters)
                {
                    switch (filter.Field.ToLower())
                    {
                        case "contractname":
                            query = query.Where(x => x.ContractName.Contains(filter.Value));
                            break;
                        case "isactive":
                            if (bool.TryParse(filter.Value, out var isActive))
                                query = query.Where(x => x.IsActive == isActive);
                            break;
                    }
                }
            }

            query = query.OrderBy(c => c.ContractID);

            response.RowsCount = await query.CountAsync(cancellationToken);

            response.LstData = await _mapper.ProjectTo<GCLQ_HRContract>(
                    query.Skip((request.PageNumber - 1) * request.PageSize)
                         .Take(request.PageSize),
                    _mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);


            return response;
        }
    }
}
