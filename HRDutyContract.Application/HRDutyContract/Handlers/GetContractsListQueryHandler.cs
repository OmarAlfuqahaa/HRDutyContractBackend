using AutoMapper;
using AutoMapper.QueryableExtensions;
using HRDutyContract.Application.Common.Interfaces;
using HRDutyContract.Application.HRDutyContract.Queries;
using HRDutyContract.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

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

            Expression<Func<HRContract, bool>> searchFilter = x => true;
            Expression<Func<HRContract, bool>> isActiveFilter = x => true;

            if (!string.IsNullOrEmpty(request.SearchTerm))
            {
                var term = request.SearchTerm;
                searchFilter = x => x.ContractName.Contains(term);
            }

            if (request.IsActive.HasValue)
            {
                isActiveFilter = x => x.IsActive == request.IsActive.Value;
            }

            var query = _context.HRContracts
                .Where(searchFilter)
                .Where(isActiveFilter)
                .OrderBy(c => c.ContractID);

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
