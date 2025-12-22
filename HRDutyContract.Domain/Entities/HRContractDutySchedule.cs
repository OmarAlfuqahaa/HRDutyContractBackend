using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HRDutyContract.Domain.Entities
{

    [Table("HR_Contract_Duty_Schedule", Schema = "dbo")]
    public class HRContractDutySchedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DetailsID { get; set; }
        public int ContractID { get; set; }
        public int CompanyID { get; set; }

        public int? ShiftTypeID { get; set; }

        public TimeSpan? FromTime { get; set; }
        public TimeSpan? ToTime { get; set; }
        public TimeSpan? ShiftTotalHours { get; set; }

        public float? Multiplier { get; set; }
        public float? InCall_Multiplier { get; set; }
        public float? OnCall_Multiplier { get; set; }

        public float? Amount { get; set; }
        public float? BaseLine { get; set; }

        public int? AllowanceTypeID { get; set; }
        public int? AllowanceTypeID2 { get; set; }

        public bool? IsWithSalaryCalculate { get; set; }
        public int? ShiftBehaviorID { get; set; }

        public float? MonthlyMaxShifts { get; set; }

        public float? HolidayMultiplier { get; set; }
        public float? HolidayInCall_Multiplier { get; set; }
        public float? HolidayOnCall_Multiplier { get; set; }

        public bool? IsActive { get; set; }

        public string? Note { get; set; }
        public string? RecordAddBy { get; set; }
        public string? RecordUpdateBy { get; set; }
        public string? RecordNote { get; set; }

        public bool? RecordDeleted { get; set; }
        public DateTime? RecordDateEntry { get; set; }
    }
}
