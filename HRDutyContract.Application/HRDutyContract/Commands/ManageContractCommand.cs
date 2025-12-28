using HRDutyContract.Application.Common.ViewModels;
using HRDutyContract.Domain.Entities;
using MediatR;

namespace HRDutyContract.Application.HRDutyContract.Commands
{
    public class ManageContractCommand : IRequest<AbstractViewModel>
    {
        public HRContract Contract { get; set; }
        public bool IsDelete { get; set; } = false;
    }
}
