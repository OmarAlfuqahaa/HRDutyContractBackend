using HRDutyContract.Application.Common.ViewModels;
using HRDutyContract.Domain.Entities;
using MediatR;

namespace HRDutyContract.Application.HRDutyContract.Commands
{
    public class ManageHRContractEmployeesCommand : IRequest<AbstractViewModel>
    {
        public List<HRContractEmployeeItem> Employees { get; set; } = new();
    }

    public class HRContractEmployeeItem
    {
        public HRContractEmployees Employee { get; set; }
        public bool IsDelete { get; set; } = false;
    }
}
