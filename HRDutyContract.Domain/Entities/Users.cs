using System.ComponentModel.DataAnnotations.Schema;

namespace HRDutyContract.Domain.Entities
{
    [Table("ACC_Users", Schema = "dbo")]
    public class Users
    {
        public int UserID { get; set; }
        public int CompanyID { get; set; }
        public string UserName { get; set; }
        public int AccID { get; set; }

        public string? SortID { get; set; }
        public string? Password { get; set; }
        public bool? IsPasswordNeverExpired { get; set; }
        public string? AccArName { get; set; }
        public string? AccEnName { get; set; }
        public int? CityID { get; set; }
        public string? Address { get; set; }
        public string? Fax { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }

        public int? SubMainDepartmentID { get; set; }
        public int? DepartmentID { get; set; }
        public int? PositionID { get; set; }
        public int? SecurityGroupID { get; set; }

        public string? ComputerName { get; set; }
        public string? IPAddress { get; set; }
        public string? CreatedDate { get; set; }
        public string? ID_Number { get; set; }
        public string? Tel { get; set; }
        public string? Note { get; set; }
        public int? GenderID { get; set; }
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
        public string? FunctionalNumber { get; set; }
        public string? CardNumber { get; set; }
        public int? AttendanceMachineID { get; set; }
        public int? BranchID { get; set; }
        public int? ResponsibleOfficerID { get; set; }
        public int? CategoryID { get; set; }
        public int? GradeID { get; set; }
        public int? StageID { get; set; }
        public int? EmployeeStatusID { get; set; }
        public byte[]? SignatureImage { get; set; }
        public int? NationalityID { get; set; }
        public string? PlaceOfBirth { get; set; }
        public int? ReligionID { get; set; }
        public int? SocialStatusID { get; set; }
        public int? EducationLevelID { get; set; }
        public int? SpecialtyID { get; set; }

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
        public double? TheRate { get; set; }
        public double? Equal_BasicSalary { get; set; }
        public double? Equal_FinalSalary { get; set; }
        public double? Equal_HourlyCost { get; set; }

        public int? MainDepartmentID { get; set; }
        public int? SubUserID { get; set; }
        public string? BranchCode { get; set; }
        public string? IbanNo { get; set; }
        public string? BankAccountNo { get; set; }
        public bool? IsBankCommitment { get; set; }

        public int? RecordAddBy { get; set; }
        public int? RecordUpdateBy { get; set; }
        public string? RecordNote { get; set; }
        public bool? RecordDeleted { get; set; }
        public DateTime? RecordDateEntry { get; set; }

        public int? EmployementTypeID { get; set; }
        public bool? IsCompanyCommitment { get; set; }
        public bool? IsProbationPeriod { get; set; }
        public int? HR_BankID { get; set; }
        public int? HR_TaxID { get; set; }
        public int? ReportingEmployeeID { get; set; }
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
        public bool? IsTemporaryAccount { get; set; }
        public string? DeviceToken { get; set; }
        public int? RoleId { get; set; }

        public int? InCallType_AllowanceTypeID { get; set; }
        public double? InCall_BaseLine { get; set; }
        public double? InCall_MaxTotal { get; set; }
        public int? OnCallType_AllowanceTypeID { get; set; }
        public double? OnCall_BaseLine { get; set; }
        public double? OnCall_MaxTotal { get; set; }

        public double? StudyLeave_Balance { get; set; }
        public bool? TheDelayInWorkingHoursIsNotCalculated { get; set; }
        public bool? IsAllowAnyRequestForTheEmployeeWithoutAnyRestrictions { get; set; }

        public int? No_Of_Children { get; set; }
        public bool? UnionMembership { get; set; }
        public DateTime? Date_Of_Practice { get; set; }
        public DateTime? ExtendProbation_ToDate { get; set; }
        public bool? IsExtendProbationPeriod { get; set; }
        public bool? IsTaxableSalary { get; set; }

        public int? CarID { get; set; }
        public int? CarTypeID { get; set; }
        public int? CarModelID { get; set; }
        public int? CarColorID { get; set; }
        public string? CarNote { get; set; }

        public bool? IsDoNotSendAnyEmailNotificationsToThisEmployee { get; set; }
        public DateTime? CompletedProbation_ToDate { get; set; }
        public bool? IsCompletedProbationPeriod { get; set; }

        public bool? IsSentEmailTo_Probation { get; set; }
        public bool? SentEmailTo_Probation { get; set; }
        public bool? IsSentEmailTo_ExtendProbation { get; set; }
        public bool? SentEmailTo_ExtendProbation { get; set; }
        public bool? IsSentEmailTo_CompletedProbation { get; set; }
        public bool? SentEmailTo_CompletedProbation { get; set; }

        public int? Old_PositionID { get; set; }
        public bool? IsSeenByUser { get; set; }
        public string? EmployeeNote { get; set; }
        public bool? IsAgreeIAH_Message { get; set; }
        public DateTime? IsActive_Date { get; set; }

        public byte[]? BinaryPassword { get; set; }
        public bool? IsUseBinaryPassword { get; set; }

        public int? RecruitmentStatusID { get; set; }
        public int? Recruitment_CreatedBy { get; set; }
        public DateTime? Recruitment_CreatedDate { get; set; }
        public int? Recruitment_UpdatedBy { get; set; }
        public DateTime? Recruitment_UpdatedDate { get; set; }

        public int? ERPEasy_ModulesID { get; set; }

        public double? Second_BasicSalary { get; set; }
        public int? Second_CurrencyID { get; set; }
        public int? Second_PaymentMethodID { get; set; }
        public string? Second_BranchCode { get; set; }
        public string? Second_IbanNo { get; set; }
        public string? Second_BankAccountNo { get; set; }

        public int? TemporaryAccountTypeID { get; set; }
        public bool? IsNotSubjectToEndOfService { get; set; }
        public string? CentralTempToken { get; set; }
        public int? DefaultProcessLevelId { get; set; }
        public bool? IsAllowToEditInvoiceTrack { get; set; }
        public string? StoreIDs { get; set; }
        public bool? IsShowInCardLogin { get; set; }

        public string? ArFirstName { get; set; }
        public string? ArSecondName { get; set; }
        public string? ArThirdName { get; set; }
        public string? ArLastName { get; set; }
        public string? EnFirstName { get; set; }
        public string? EnSecondName { get; set; }
        public string? EnThirdName { get; set; }
        public string? EnLastName { get; set; }

        public int? Mapping_UserID { get; set; }
        public bool? IsUnder_SocialSecurity { get; set; }
        public int? SocialSecurity_AccID { get; set; }
        public double? SocialSecurity_CustomSalary { get; set; }
        public string? MainForm_DashboardPath { get; set; }

        public int? BirthCountryID { get; set; }
        public int? CountryID { get; set; }
        public int? MilitaryStatusID { get; set; }
        public string? MilitaryID { get; set; }

        public string? SocialSecurityNumber { get; set; }
        public int? SocialSecurityStatusID { get; set; }
        public DateTime? SocialSecurity_FromDate { get; set; }
        public DateTime? SocialSecurity_ToDate { get; set; }

        public string? TaxNumber { get; set; }
        public bool? IsFixed_SocialSecurity { get; set; }
        public bool? IsSecond_SocialSecurity { get; set; }
        public int? ContactID { get; set; }
        public string? SocialSecurityNotes { get; set; }
        public string? NationalID { get; set; }
        public DateTime? UnionMembershipExpiryDate { get; set; }
        public DateTime? IsBankCommitmentDate { get; set; }

        public int? Current_ContractDetailsID { get; set; }
        public int? Count_Contract { get; set; }

        public string? SystemDefault_Language { get; set; }

        public string? DataMigration_Field1 { get; set; }
        public string? DataMigration_Field2 { get; set; }
        public string? DataMigration_Field3 { get; set; }
        public string? DataMigration_Field4 { get; set; }
        public string? DataMigration_Field5 { get; set; }
        public bool? IsDataMigration { get; set; }
    }

}
