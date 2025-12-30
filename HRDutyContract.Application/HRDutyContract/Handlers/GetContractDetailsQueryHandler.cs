using AutoMapper;
using HRDutyContract.Application.Common.Interfaces;
using HRDutyContract.Application.HRDutyContract.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRDutyContract.Application.HRDutyContract.Handlers
{
    public class GetContractDetailsByIdQueryHandler : IRequestHandler<GetContractDetailsByIdQuery, GCD_Response>
    {
        private readonly IHRContext _context;
        private readonly IMapper _mapper;

        public GetContractDetailsByIdQueryHandler(IHRContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GCD_Response> Handle(GetContractDetailsByIdQuery request, CancellationToken cancellationToken)
        {
            var query = _context.HRContracts
                                .Where(c => c.ContractID == request.ContractID);

            var result = await _mapper.ProjectTo<GCD_Response>(
                            query,
                            _mapper.ConfigurationProvider)
                        .FirstOrDefaultAsync(cancellationToken);

            return result;
        }
    }
}