using HRDutyContract.Application.Common.ViewModels;
using HRDutyContract.Domain.Entities;
using MediatR;

namespace HRDutyContract.Application.HRDutyContract.Commands
{
    public class ManageHRContractMonthlyShiftCommand : IRequest<AbstractViewModel>
    {
        public HRContractMonthlyShifts Shift { get; set; }
        public bool IsDelete { get; set; } = false;
    }
}
