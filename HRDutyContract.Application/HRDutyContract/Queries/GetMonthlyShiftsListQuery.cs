using MediatR;

namespace HRDutyContract.Application.HRDutyContract.Queries
{
    public class GetMonthlyShiftsListQuery : IRequest<GMLQ_Response>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public List<FilterItem>? Filters { get; set; }
    }

    public class GMLQ_HRContractMonthlyShift
    {
        public int DetailsID { get; set; }
        public int ContractID { get; set; }
        public int CompanyID { get; set; }

        public int? Month { get; set; }
        public int? Year { get; set; }
        public double? TotalShifts { get; set; }
        public double? TotalHours { get; set; }
        public bool? IsActive { get; set; }
        public string? Note { get; set; }
    }

    public class GMLQ_Response
    {
        public List<GMLQ_HRContractMonthlyShift> LstData { get; set; } = new();
        public int RowsCount { get; set; }
    }


}
