using HRDutyContract.Application.Common.ViewModels;
using HRDutyContract.Domain.Entities;
using MediatR;

namespace HRDutyContract.Application.HRDutyContract.Queries
{
    public class GetEmployeesWithoutContractGroupedByDepartmentQuery : IRequest<Dictionary<int?, List<Users>>>
    {
    }

}
