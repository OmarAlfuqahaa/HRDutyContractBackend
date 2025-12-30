using AutoMapper;
using HRDutyContract.Application.Common.Interfaces;
using HRDutyContract.Application.HRDutyContract.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRDutyContract.Application.HRDutyContract.Handlers
{
    public class GetContractsListQueryHandler
    : IRequestHandler<GetContractsListQuery, GCLQ_Response>
    {
        private readonly IHRContext _context;
        private readonly IMapper _mapper;

        public GetContractsListQueryHandler(IHRContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GCLQ_Response> Handle(
            GetContractsListQuery request,
            CancellationToken cancellationToken)
        {
            var query = _context.HRContracts
                .AsNoTracking()
                .AsQueryable();


            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var search = request.SearchTerm.Trim();

                query = query.Where(x =>
                    x.ContractName != null &&
                    x.ContractName.Contains(search));
            }

            if (request.IsActive.HasValue)
            {
                query = query.Where(x => x.IsActive == request.IsActive.Value);
            }

            var rowsCount = await query.CountAsync(cancellationToken);

            query = query.OrderBy(x => x.ContractID);

            if (request.PageSize != -1)
            {
                query = query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize);
            }

            var data = await _mapper.ProjectTo<GCLQ_HRContract>(
                    query,
                    _mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new GCLQ_Response
            {
                LstData = data,
                RowsCount = rowsCount
            };
        }

    }

}
