using MediatR;

namespace HRDutyContract.Application.HRDutyContract.Queries
{
    public class GetDepartmentsListQuery : IRequest<GDLQ_Response>
    {
        public bool? IsActive { get; set; }
        public int? ContractId { get; set; }

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10; 
    }


    public class GDLQ_HRContractDepartment
    {
        public int DetailsID { get; set; }
        public int ContractID { get; set; }
        public int? DepartmentID { get; set; }
        public bool? IsActive { get; set; }
        public string? Note { get; set; }
    }

    public class GDLQ_Response
    {
        public List<GDLQ_HRContractDepartment> LstData { get; set; } = new();
        public int RowsCount { get; set; }
    }


}
