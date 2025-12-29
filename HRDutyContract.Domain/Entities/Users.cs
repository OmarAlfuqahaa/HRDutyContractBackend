using System.ComponentModel.DataAnnotations.Schema;

namespace HRDutyContract.Domain.Entities
{
    [Table("View_ACC_Users_List", Schema = "dbo")]
    public class Users
    {
        public int UserID { get; set; }
        public int CompanyID { get; set; }
        public string UserName { get; set; } = null!;
        public int AccID { get; set; }

        public string? SortID { get; set; }
        public string? SortArName { get; set; }
        public string? SortEnName { get; set; }

        public string? Password { get; set; }
        public bool? IsPasswordNeverExpired { get; set; }

        public string? AccArName { get; set; }
        public string? AccEnName { get; set; }

        public int? CityID { get; set; }
        public string? CityArName { get; set; }
        public string? CityEnName { get; set; }

        public string? Address { get; set; }
        public string? Fax { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }

        public int? DepartmentID { get; set; }
        public string? DepartmentArName { get; set; }
        public string? DepartmentEnName { get; set; }

        public int? PositionID { get; set; }
        public string? PositionArName { get; set; }
        public string? PositionEnName { get; set; }

        public int? SecurityGroupID { get; set; }
        public string? SecurityGroupArName { get; set; }
        public string? SecurityGroupEnName { get; set; }

        public string? ComputerName { get; set; }
        public string? IPAddress { get; set; }

        public string? CreatedDate { get; set; }
        public string? ID_Number { get; set; }
        public string? Tel { get; set; }
        public string? Note { get; set; }

        public int? GenderID { get; set; }
        public string? GenderArName { get; set; }
        public string? GenderEnName { get; set; }

        public DateTime? Birth_Date { get; set; }
        public Guid? AttachmentUID { get; set; }
        public byte[]? UserImage { get; set; }

        public DateTime? ExpiryDate { get; set; }
        public DateTime? CreateDate { get; set; }

        public bool? IsActive { get; set; }
        public bool? IsForOnlyCurrentIP { get; set; }
        public bool? IsUseCasheirPassword { get; set; }
        public string? CashierBoxPassword { get; set; }

        public int? ContractID { get; set; }
        public string? ContractName { get; set; }
        public string? FunctionalNumber { get; set; }
        public string? CardNumber { get; set; }

        public int? AttendanceMachineID { get; set; }

        public int? BranchID { get; set; }
        public string? BranchArName { get; set; }
        public string? BranchEnName { get; set; }

        public int? ResponsibleOfficerID { get; set; }

        public int? CategoryID { get; set; }
        public string? CategoryArName { get; set; }
        public string? CategoryEnName { get; set; }

        public int? GradeID { get; set; }
        public string? GradeArName { get; set; }
        public string? GradeEnName { get; set; }

        public int? StageID { get; set; }
        public string? StageArName { get; set; }
        public string? StageEnName { get; set; }

        public int? EmployeeStatusID { get; set; }
        public string? EmployeeStatusArName { get; set; }
        public string? EmployeeStatusEnName { get; set; }

        public byte[]? SignatureImage { get; set; }

        public int? NationalityID { get; set; }
        public string? NationalityArName { get; set; }
        public string? NationalityEnName { get; set; }

        public string? PlaceOfBirth { get; set; }
        public string? PlaceOfBirthArName { get; set; }
        public string? PlaceOfBirthEnName { get; set; }

        public int? ReligionID { get; set; }
        public string? ReligionArName { get; set; }
        public string? ReligionEnName { get; set; }

        public int? SocialStatusID { get; set; }
        public string? SocialStatusArName { get; set; }
        public string? SocialStatusEnName { get; set; }

        public int? EducationLevelID { get; set; }
        public string? EducationLevelArName { get; set; }
        public string? EducationLevelEnName { get; set; }

        public int? SpecialtyID { get; set; }
        public string? SpecialtyArName { get; set; }
        public string? SpecialtyEnName { get; set; }

        public DateTime? DateOfHiring { get; set; }
        public DateTime? DateOfStartJob { get; set; }
        public DateTime? DateOfEndJob { get; set; }
        public DateTime? DateOfEndContract { get; set; }

        public string? Mobile2 { get; set; }
        public string? Tel2 { get; set; }

        public string? FaceBook { get; set; }
        public string? Twitter { get; set; }
        public string? LinkedIn { get; set; }

        public double? BasicSalary { get; set; }
        public double? FinalSalary { get; set; }
        public double? Total_Extempt { get; set; }
        public double? Final_SalaryAfterTax { get; set; }
        public double? SalaryTax_Percentage { get; set; }
        public double? SalaryTax_Amount { get; set; }

        public int? PaymentMethodID { get; set; }
        public string? PaymentMethodArName { get; set; }
        public string? PaymentMethodEnName { get; set; }

        public bool? IsOverTimeAllowance { get; set; }
        public bool? IsSubjectToInsurance { get; set; }
        public bool? IsSubjectToSocialSecurity { get; set; }
        public bool? IsEndOfServiceIndemnity { get; set; }
        public bool? IsSubjectToTax { get; set; }
        public bool? IsResident { get; set; }
        public bool? IsHusbandWifeExempt { get; set; }
        public bool? IsChildrensNotExempt { get; set; }

        public double? AnnualRent_Amount { get; set; }
        public DateTime? AnnualRent_FromDate { get; set; }
        public DateTime? AnnualRent_ToDate { get; set; }

        public double? ExemptAdvance_Amount { get; set; }
        public DateTime? ExemptAdvance_FromDate { get; set; }
        public DateTime? ExemptAdvance_ToDate { get; set; }

        public double? MobilityAllowance_Amount { get; set; }
        public DateTime? MobilityAllowance_FromDate { get; set; }
        public DateTime? MobilityAllowance_ToDate { get; set; }

        public bool? IsBasicSalary { get; set; }
        public bool? IsHourlyCost { get; set; }
        public double? HourlyCost { get; set; }

        public bool? IsSubjectToTheFingerprint { get; set; }
        public double? AllowanceAmount { get; set; }
        public double? DeductionAmount { get; set; }

        public double? Equal_AllowanceAmount { get; set; }
        public double? Equal_DeductionAmount { get; set; }

        public int? CurrencyID { get; set; }
        public string? CurrencyArName { get; set; }
        public string? CurrencyEnName { get; set; }

        public double? TheRate { get; set; }
        public double? Equal_BasicSalary { get; set; }
        public double? Equal_FinalSalary { get; set; }
        public double? Equal_HourlyCost { get; set; }

        public string? MainDepartmentID { get; set; }
        public string? MainDepartmentArName { get; set; }
        public string? MainDepartmentEnName { get; set; }

        public string? SubUserID { get; set; }
        public string? BranchCode { get; set; }
        public string? IbanNo { get; set; }
        public string? BankAccountNo { get; set; }
        public bool? IsBankCommitment { get; set; }

        public string? RecordAddBy { get; set; }
        public string? RecordUpdateBy { get; set; }
        public string? RecordNote { get; set; }
        public bool? RecordDeleted { get; set; }
        public DateTime? RecordDateEntry { get; set; }

        public int? EmployementTypeID { get; set; }
        public string? EmployementTypeArName { get; set; }
        public string? EmployementTypeEnName { get; set; }

        public bool? IsCompanyCommitment { get; set; }
        public bool? IsProbationPeriod { get; set; }

        public int? HR_BankID { get; set; }
        public string? HR_BankArName { get; set; }
        public string? HR_BankEnName { get; set; }

        public int? HR_TaxID { get; set; }
        public long? ReportingEmployeeID { get; set; }
        public DateTime? Probation_ToDate { get; set; }

        public bool? IsNotTaxableSalary { get; set; }
        public bool? IsShift_Value { get; set; }
        public double? Shift_Value { get; set; }

        public bool? IsEmployeeExemptions { get; set; }
        public double? FixedAmount_ForExtraShift { get; set; }
        public double? NightShift_Amount { get; set; }

        public bool? IsSpecialTax { get; set; }
        public double? SpecialTax_Amount { get; set; }

        public int? DefaultFormID { get; set; }
        public string? DefaultFormArName { get; set; }
        public string? DefaultFormEnName { get; set; }

        public bool? IsTemporaryAccount { get; set; }
        public string? DeviceToken { get; set; }
        public int? RoleId { get; set; }

        public int? InCallType_AllowanceTypeID { get; set; }
        public string? InCallType_AllowanceTypeArName { get; set; }
        public string? InCallType_AllowanceTypeEnName { get; set; }
        public double? InCall_BaseLine { get; set; }
        public double? InCall_MaxTotal { get; set; }

        public int? OnCallType_AllowanceTypeID { get; set; }
        public string? OnCallType_AllowanceTypeArName { get; set; }
        public string? OnCallType_AllowanceTypeEnName { get; set; }
        public double? OnCall_BaseLine { get; set; }
        public double? OnCall_MaxTotal { get; set; }

        public double? StudyLeave_Balance { get; set; }
        public bool? TheDelayInWorkingHoursIsNotCalculated { get; set; }
        public bool? IsAllowAnyRequestForTheEmployeeWithoutAnyRestrictions { get; set; }

        public string? No_Of_Children { get; set; }
        public string? UnionMembership { get; set; }
        public string? Date_Of_Practice { get; set; }

        public int? SubMainDepartmentID { get; set; }
        public string? SubMainDepartmentArName { get; set; }
        public string? SubMainDepartmentEnName { get; set; }

        public bool? IsSeenByUser { get; set; }
        public bool? IsAgreeIAH_Message { get; set; }
        public string? EmployeeNote { get; set; }

        public int? RecruitmentStatusID { get; set; }
        public string? Recruitment_CreatedBy { get; set; }
        public DateTime? Recruitment_CreatedDate { get; set; }
        public string? Recruitment_UpdatedBy { get; set; }
        public DateTime? Recruitment_UpdatedDate { get; set; }

        public int? Duty_ContractID { get; set; }
        public string? Duty_ContractName { get; set; }

        public int? ServiceYears { get; set; }
    }

}
