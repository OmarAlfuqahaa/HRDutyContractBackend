using HRDutyContract.Application.HRDutyContract.Commands;
using HRDutyContract.Application.HRDutyContract.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRDutyContractBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HRContractEmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HRContractEmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Manage")]
        public async Task<IActionResult> Manage([FromBody] ManageHRContractEmployeesCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpGet("List")]
        public async Task<IActionResult> GetEmployeesList(
            [FromQuery] bool? isActive,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            var query = new GetEmployeesListQuery
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            
            if (isActive.HasValue)
            {
                query.Filters = new List<FilterItem>
                {
                    new FilterItem { Field = "IsActive", Value = isActive.Value.ToString() }
                };
            }

            var result = await _mediator.Send(query);
            return Ok(result);
        }


    }
}
