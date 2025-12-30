using HRDutyContract.Application.Common.ViewModels;
using HRDutyContract.Domain.Entities;
using MediatR;


namespace HRDutyContract.Application.HRDutyContract.Commands
{
    public class ManageHRContractDepartmentsCommand : IRequest<AbstractViewModel>
    {
        public List<HRContractDepartmentItem> Departments { get; set; } = new();
    }

    public class HRContractDepartmentItem
    {
        public HRContractDepartment Department { get; set; }
        public bool IsDelete { get; set; } = false;
    }
} 