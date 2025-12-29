using HRDutyContract.Application.HRDutyContract.Queries;
using HRDutyContract.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRDutyContractBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HRReportsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HRReportsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/HRUsers/WithoutContracts
        [HttpGet("WithoutContracts")]
        public async Task<ActionResult<List<Users>>> GetEmployeesWithoutContracts()
        {
            var query = new GetEmployeesWithoutContractsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // GET: api/HRUsers/WithoutContractsGroupedByDepartment
        [HttpGet("WithoutContractsGroupedByDepartment")]
        public async Task<ActionResult<Dictionary<int?, List<Users>>>> GetEmployeesWithoutContractGroupedByDepartment()
        {
            var query = new GetEmployeesWithoutContractGroupedByDepartmentQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
