using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRDutyContract.Application.HRDutyContract.Queries
{
    public class GetHRContractDepartmentListQuery
        : IRequest<List<HRCD_Response>>
    {
        public int? ContractID { get; set; }
        public bool? IsActive { get; set; }
    }

    public class HRCD_Response
    {
        public int DetailsID { get; set; }
        public int ContractID { get; set; }
        public int CompanyID { get; set; }
        public int? DepartmentID { get; set; }
        public bool? IsActive { get; set; }
        public string? Note { get; set; }
    }
}
