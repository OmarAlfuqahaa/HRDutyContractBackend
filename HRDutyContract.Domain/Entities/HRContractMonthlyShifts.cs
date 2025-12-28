using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRDutyContract.Domain.Entities
{
    [Table("HR_Contract_Monthly_Shifts", Schema = "dbo")]

    public class HRContractMonthlyShifts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DetailsID { get; set; }
        public int ContractID { get; set; }
        public int CompanyID { get; set; }

        public int? Month { get; set; }
        public int? Year { get; set; }

        public double? TotalShifts { get; set; }
        public double? TotalHours { get; set; }

        public bool? IsActive { get; set; }

        public string? Note { get; set; }
        public string? RecordAddBy { get; set; }
        public string? RecordUpdateBy { get; set; }
        public string? RecordNote { get; set; }

        public bool? RecordDeleted { get; set; }
        public DateTime? RecordDateEntry { get; set; }
    }
}
