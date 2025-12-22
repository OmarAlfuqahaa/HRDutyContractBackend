using AutoMapper;
using HRDutyContract.Domain.Entities;
using HRDutyContract.Application.HRDutyContract.Queries;

namespace HRDutyContract.Application.Common.Mappings
{
    public class HRContractProfile : Profile
    {
        public HRContractProfile()
        {
            CreateMap<HRContract, GCLQ_HRContract>()
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive ?? false))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.RecordDateEntry.HasValue
                    ? src.RecordDateEntry.Value.ToString("yyyy-MM-dd")
                    : null));

        }
    }
}
