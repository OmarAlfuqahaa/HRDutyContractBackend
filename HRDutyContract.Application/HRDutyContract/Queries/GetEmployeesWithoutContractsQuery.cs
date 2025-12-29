using HRDutyContract.Domain.Entities;
using MediatR;


namespace HRDutyContract.Application.HRDutyContract.Queries
{
    public class GetEmployeesWithoutContractsQuery : IRequest<List<Users>>
    {
    }
}
