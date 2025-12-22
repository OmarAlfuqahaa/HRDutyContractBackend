using HRDutyContract.Application.Common.ViewModels;
using HRDutyContract.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRDutyContract.Application.HRDutyContract.Commands
{
    public class ManageContractCommand : IRequest<AbstractViewModel>
    {
        public HRContract Contract { get; set; }
        public bool IsDelete { get; set; } = false; 
    }
}
