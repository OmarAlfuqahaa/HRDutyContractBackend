using HRDutyContract.Application.Common.ViewModels;
using HRDutyContract.Domain.Entities;
using MediatR;


namespace HRDutyContract.Application.HRDutyContract.Queries
{
    public class GetEmployeesWithoutContractsQuery : IRequest<GEWC_Response>
    {
        public int? CompanyId { get; set; }
    }


    public class GEWC_User
    {
        public string UserName { get; set; } = string.Empty;
        public string AccArName { get; set; } = string.Empty;
    }

    public class GEWC_Response
    {
        public List<GEWC_User> LstData { get; set; } = new();
        public int RowsCount { get; set; }
    }

}
