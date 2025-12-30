using MediatR;


namespace HRDutyContract.Application.HRDutyContract.Queries
{
    public class GetHRContractDutyScheduleListQuery : IRequest<HRCDS_ListResponse>
    {
        public int? ContractID { get; set; }
        public bool? IsActive { get; set; }

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class HRCDS_Response
    {
        public int DetailsID { get; set; }
        public int ContractID { get; set; }
        public int CompanyID { get; set; }

        public int? ShiftTypeID { get; set; }

        public TimeSpan? FromTime { get; set; }
        public TimeSpan? ToTime { get; set; }
        public TimeSpan? ShiftTotalHours { get; set; }

        public double? Multiplier { get; set; }
        public double? InCall_Multiplier { get; set; }
        public double? OnCall_Multiplier { get; set; }

        public double? Amount { get; set; }
        public double? BaseLine { get; set; }

        public int? AllowanceTypeID { get; set; }
        public int? AllowanceTypeID2 { get; set; }

        public bool? IsWithSalaryCalculate { get; set; }
        public int? ShiftBehaviorID { get; set; }

        public double? MonthlyMaxShifts { get; set; }

        public double? HolidayMultiplier { get; set; }
        public double? HolidayInCall_Multiplier { get; set; }
        public double? HolidayOnCall_Multiplier { get; set; }

        public bool? IsActive { get; set; }

        public string? Note { get; set; }
        public string? RecordNote { get; set; }

    }

    public class HRCDS_ListResponse
    {
        public List<HRCDS_Response> LstData { get; set; } = new();
        public int RowsCount { get; set; }
    }


}