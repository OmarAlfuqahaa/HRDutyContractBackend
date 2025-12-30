using MediatR;

namespace HRDutyContract.Application.HRDutyContract.Queries
{
    public class GetContractsListQuery : IRequest<GCLQ_Response>
    {
        public string? SearchTerm { get; set; }
        public bool? IsActive { get; set; }

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }


    public class GCLQ_HRContract
    {
        public int ContractID { get; set; }
        public string? ContractName { get; set; }
        public bool IsActive { get; set; }
        public string? ExpirationDate { get; set; }
    }

    public class GCLQ_Response
    {
        public List<GCLQ_HRContract> LstData { get; set; } = new();
        public int RowsCount { get; set; }
    }
}
