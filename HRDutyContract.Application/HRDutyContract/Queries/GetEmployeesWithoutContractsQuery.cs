using MediatR;


namespace HRDutyContract.Application.HRDutyContract.Queries
{
    public class GetEmployeesWithoutContractsQuery
     : IRequest<GEWC_Response>
    {
        public int? CompanyId { get; set; }
        public string? SearchTerm { get; set; }
    }


    public class GEWC_User
    {
        public string UserName { get; set; } = string.Empty;
        public string AccArName { get; set; } = string.Empty;
    }

    public class GEWC_DepartmentGroup
    {
        public int? DepartmentID { get; set; }
        public string? DepartmentArName { get; set; }
        public List<GEWC_User> Users { get; set; } = new();
    }

    public class GEWC_Response
    {
        public List<GEWC_DepartmentGroup> LstData { get; set; } = new();
        public int RowsCount { get; set; }
    }
}