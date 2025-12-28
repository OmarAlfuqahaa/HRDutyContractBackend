using MediatR;

namespace HRDutyContract.Application.HRDutyContract.Queries
{
    public class GetEmployeesListQuery : IRequest<GELQ_Response>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public List<FilterItem>? Filters { get; set; }
    }

    public class GELQ_HRContractEmployees
    {
        public int DetailsID { get; set; }
        public int ContractID { get; set; }
        public int CompanyID { get; set; }

        public int? UserID { get; set; }
        public bool? IsActive { get; set; }

        public string? Note { get; set; }
        public string? RecordAddBy { get; set; }
        public string? RecordUpdateBy { get; set; }
        public string? RecordNote { get; set; }

        public bool? RecordDeleted { get; set; }
        public DateTime? RecordDateEntry { get; set; }

        public int? OvertimeTypeID_NormalDuty { get; set; }
        public double? Multiplier_NormalDuty { get; set; }

        public int? OvertimeTypeID_InVacation { get; set; }
        public double? Multiplier_InVacation { get; set; }

        public double? Multiplier_NormalDuty_FromRange { get; set; }
        public double? Multiplier_NormalDuty_ToRange { get; set; }

        public double? NextMultiplier_NormalDuty { get; set; }
        public double? NextMultiplier_NormalDuty_FromRange { get; set; }
        public double? NextMultiplier_NormalDuty_ToRange { get; set; }
    }

    public class GELQ_Response
    {
        public List<GELQ_HRContractEmployees> LstData { get; set; } = new();
        public int RowsCount { get; set; }
    }


}
