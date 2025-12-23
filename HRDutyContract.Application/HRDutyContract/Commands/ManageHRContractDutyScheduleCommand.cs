using HRDutyContract.Application.Common.ViewModels;
using HRDutyContract.Domain.Entities;
using MediatR;

namespace HRDutyContract.Application.HRDutyContract.Commands
{
    public class ManageHRContractDutyScheduleCommand : IRequest<AbstractViewModel>
    {
        public HRContractDutySchedule Schedule { get; set; }
        public bool IsDelete { get; set; } = false; 
    }
}
