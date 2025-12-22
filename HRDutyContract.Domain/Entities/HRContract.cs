using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRDutyContract.Domain.Entities
{
    [Table("HR_Contract", Schema = "dbo")]
    public class HRContract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContractID { get; set; }

        public int CompanyID { get; set; }

        [MaxLength(50)]
        public string? ContractName { get; set; }

        public DateTime? ContractDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool? IsNoExpirationDate { get; set; }

        [MaxLength(50)]
        public string? AttendanceTime { get; set; }

        [MaxLength(50)]
        public string? TimeOfDeparture { get; set; }

        public int? AttendancePermissionID { get; set; }
        public int? DeparturePermissionID { get; set; }

        [MaxLength(50)]
        public string? BeginAttendance { get; set; }

        [MaxLength(50)]
        public string? EndAttendance { get; set; }

        public int? DayStartOfTheWeekID { get; set; }
        public int? TotalDutyTimeID { get; set; }
        public int? TotalMorningDelayID { get; set; }
        public int? TotalEveningDelayID { get; set; }

        public bool? IsSaturday { get; set; }
        public bool? IsSunday { get; set; }
        public bool? IsMonday { get; set; }
        public bool? IsTuesday { get; set; }
        public bool? IsWednesday { get; set; }
        public bool? IsThursday { get; set; }
        public bool? IsFriday { get; set; }

        public bool? IsSubjectToDutySchedule { get; set; }
        public bool? IsActive { get; set; }

        public string? IsFridayHours { get; set; }
        public string? IsSaturdayHours { get; set; }
        public string? IsSundayHours { get; set; }
        public string? IsMondayHours { get; set; }
        public string? IsTuesdayHours { get; set; }
        public string? IsWednesdayHours { get; set; }
        public string? IsThursdayHours { get; set; }

        public double? MaxExtraShifts { get; set; }

        [MaxLength(50)]
        public string? Note { get; set; }

        [MaxLength(50)]
        public string? RecordAddBy { get; set; }

        [MaxLength(50)]
        public string? RecordUpdateBy { get; set; }

        [MaxLength(250)]
        public string? RecordNote { get; set; }

        public bool? RecordDeleted { get; set; }

        public DateTime? RecordDateEntry { get; set; }

        public bool? IsDetuct_LeaveHours { get; set; }

        [MaxLength(50)]
        public string? IsFridayFrom { get; set; }
        [MaxLength(50)]
        public string? IsSaturdayFrom { get; set; }
        [MaxLength(50)]
        public string? IsSundayFrom { get; set; }
        [MaxLength(50)]
        public string? IsMondayFrom { get; set; }
        [MaxLength(50)]
        public string? IsTuesdayFrom { get; set; }
        [MaxLength(50)]
        public string? IsWednesdayFrom { get; set; }
        [MaxLength(50)]
        public string? IsThursdayFrom { get; set; }

        [MaxLength(50)]
        public string? IsFridayTo { get; set; }
        [MaxLength(50)]
        public string? IsSaturdayTo { get; set; }
        [MaxLength(50)]
        public string? IsSundayTo { get; set; }
        [MaxLength(50)]
        public string? IsMondayTo { get; set; }
        [MaxLength(50)]
        public string? IsTuesdayTo { get; set; }
        [MaxLength(50)]
        public string? IsWednesdayTo { get; set; }
        [MaxLength(50)]
        public string? IsThursdayTo { get; set; }

        [MaxLength(50)]
        public string? IsFridayOverTimeAfter { get; set; }
        [MaxLength(50)]
        public string? IsSaturdayOverTimeAfter { get; set; }
        [MaxLength(50)]
        public string? IsSundayOverTimeAfter { get; set; }
        [MaxLength(50)]
        public string? IsMondayOverTimeAfter { get; set; }
        [MaxLength(50)]
        public string? IsTuesdayOverTimeAfter { get; set; }
        [MaxLength(50)]
        public string? IsWednesdayOverTimeAfter { get; set; }
        [MaxLength(50)]
        public string? IsThursdayOverTimeAfter { get; set; }

        public bool? IsCalculateOverTime_After_Daily_Duration { get; set; }
        public bool? IsCalculateOverTime_After_OT_After_Value { get; set; }

        [MaxLength(50)]
        public string? IsFridayOverTimeBefore { get; set; }
        [MaxLength(50)]
        public string? IsSaturdayOverTimeBefore { get; set; }
        [MaxLength(50)]
        public string? IsSundayOverTimeBefore { get; set; }
        [MaxLength(50)]
        public string? IsMondayOverTimeBefore { get; set; }
        [MaxLength(50)]
        public string? IsTuesdayOverTimeBefore { get; set; }
        [MaxLength(50)]
        public string? IsWednesdayOverTimeBefore { get; set; }
        [MaxLength(50)]
        public string? IsThursdayOverTimeBefore { get; set; }

        public bool? IsCalculateOverTime_After_OT_Before_Value { get; set; }
        public bool? IsNo_OverTime { get; set; }
        public string? IsDefaultHours { get; set; }
        public string? IsDefaultOverTimeBefore { get; set; }
        public string? IsDefaultOverTimeAfter { get; set; }
        public bool? IsDutyContractAccordingToEmployees { get; set; }
        public bool? IsDutyContractAccordingToDepartments { get; set; }
        public bool? IsSendAnEmailWhenThereIsNoFingerprint { get; set; }
        public bool? IsSendAnEmailWhenThereIsNoCheckInOrCheckOut { get; set; }

        public bool? IsOfficialOffDay_IsFriday { get; set; }
        public bool? IsOfficialOffDay_IsSaturday { get; set; }
        public bool? IsOfficialOffDay_IsSunday { get; set; }
        public bool? IsOfficialOffDay_IsMonday { get; set; }
        public bool? IsOfficialOffDay_IsTuesday { get; set; }
        public bool? IsOfficialOffDay_IsWednesday { get; set; }
        public bool? IsOfficialOffDay_IsThursday { get; set; }

        public bool? IsAdjustDifferenceInTotalInOutDurationFrom_FinalOverTime { get; set; }
        public bool? IsCalculate_DutyTotalDays_By_Total_In_Out { get; set; }
        public bool? IsAdjustTotalLeaveRequestInTotalInOutDuration { get; set; }

        public double? Holiday_Multiplier_Amount { get; set; }
        public double? MaxExpiryDays_OffDueBalance { get; set; }
        public bool? IsGiveOffDueIfTheEmployeeWorkedInHoliday { get; set; }
        public bool? IsApplyHolidaySettings { get; set; }
        public bool? IsUseBasicSalaryAsHolidayMultiplier { get; set; }
        public bool? IsUseFixedHolidayMultiplier { get; set; }

        public int? Department_OvertimeTypeID_NormalDuty { get; set; }
        public double? Department_Multiplier_NormalDuty { get; set; }
        public int? Department_OvertimeTypeID_InVacation { get; set; }
        public double? Department_Multiplier_InVacation { get; set; }
        public double? Department_Multiplier_NormalDuty_FromRange { get; set; }
        public double? Department_Multiplier_NormalDuty_ToRange { get; set; }
        public double? Department_NextMultiplier_NormalDuty { get; set; }
        public double? Department_NextMultiplier_NormalDuty_FromRange { get; set; }
        public double? Department_NextMultiplier_NormalDuty_ToRange { get; set; }

        public double? DeservedWeeklyOffHours { get; set; }
        public double? RequestedShifts { get; set; }
    }

}