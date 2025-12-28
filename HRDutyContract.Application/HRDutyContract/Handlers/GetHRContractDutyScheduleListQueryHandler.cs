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

        public async Task<HRCDS_ListResponse> Handle(GetHRContractDutyScheduleListQuery request, CancellationToken cancellationToken)
        {
            var query = _context.HRContractDutySchedules.AsQueryable();

            if (request.ContractID.HasValue)
                query = query.Where(x => x.ContractID == request.ContractID.Value);

            if (request.IsActive.HasValue)
                query = query.Where(x => x.IsActive == request.IsActive.Value);

            query = query.OrderBy(x => x.DetailsID);

            var response = new HRCDS_ListResponse
            {
                RowsCount = await query.CountAsync(cancellationToken),
                LstData = await _mapper.ProjectTo<HRCDS_Response>(
                            query.Skip((request.PageNumber - 1) * request.PageSize)
                                 .Take(request.PageSize),
                            _mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken)
            };

            return response;
        }
    }

}
