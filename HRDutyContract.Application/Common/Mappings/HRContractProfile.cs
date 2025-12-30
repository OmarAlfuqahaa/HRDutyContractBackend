using AutoMapper;
using HRDutyContract.Application.HRDutyContract.Queries;
using HRDutyContract.Domain.Entities;

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

            CreateMap<HRContractDepartment, HRContractDepartment>()
                    .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<HRContractEmployees, HRContractEmployees>()
                    .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<HRContractDepartment, GDLQ_HRContractDepartment>();
            CreateMap<HRContractEmployees, GELQ_HRContractEmployees>();
            CreateMap<HRContractMonthlyShifts, GMLQ_HRContractMonthlyShift>();



        }
    }
}
