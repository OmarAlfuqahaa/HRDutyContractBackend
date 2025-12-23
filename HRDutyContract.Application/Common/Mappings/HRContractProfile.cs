using AutoMapper;
using HRDutyContract.Domain.Entities;
using HRDutyContract.Application.HRDutyContract.Queries;

namespace HRDutyContract.Application.Common.Mappings
{
    public class HRContractProfile : Profile
    {
        public HRContractProfile()
        {
            CreateMap<HRContract, GCD_Response>()
            .ForMember(dest => dest.IsActive,
                opt => opt.MapFrom(src => src.IsActive ?? false));

            CreateMap<HRContract, GCLQ_HRContract>()
                .ForMember(dest => dest.IsActive,
                    opt => opt.MapFrom(src => src.IsActive ?? false));

            CreateMap<HRContractDutySchedule, HRCDS_Response>();


        }
    }
}
