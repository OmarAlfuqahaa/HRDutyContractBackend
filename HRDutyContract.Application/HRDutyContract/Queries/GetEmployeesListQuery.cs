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
        public int? UserID { get; set; }
        public bool? IsActive { get; set; }
        public string? Note { get; set; }
    }

    public class GELQ_Response
    {
        public List<GELQ_HRContractEmployees> LstData { get; set; } = new();
        public int RowsCount { get; set; }
    }


}
