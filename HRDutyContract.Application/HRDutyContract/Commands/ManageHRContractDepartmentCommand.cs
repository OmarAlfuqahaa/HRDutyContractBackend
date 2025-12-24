using HRDutyContract.Application.Common.ViewModels;
using HRDutyContract.Domain.Entities;
using MediatR;


namespace HRDutyContract.Application.HRDutyContract.Commands
{
    public class ManageHRContractDepartmentCommand
       : IRequest<AbstractViewModel>
    {
        public HRContractDepartment Department { get; set; }
        public bool IsDelete { get; set; } = false;
    }
}
