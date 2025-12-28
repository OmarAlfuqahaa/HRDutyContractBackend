using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRDutyContract.Domain.Entities
{
    [Table("HR_Contract_Employees", Schema = "dbo")]

    public class HRContractEmployees
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
}
