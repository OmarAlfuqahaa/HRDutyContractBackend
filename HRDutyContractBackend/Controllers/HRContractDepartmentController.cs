using HRDutyContract.Application.HRDutyContract.Commands;
using HRDutyContract.Application.HRDutyContract.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRDutyContractBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HRContractDepartmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HRContractDepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Manage")]
        public async Task<IActionResult> Manage(
                [FromBody] ManageHRContractDepartmentsCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.status)
                return BadRequest(result);

            return Ok(result);
        }


        [HttpGet("List")]
        public async Task<IActionResult> GetDepartmentsList(
             [FromQuery] bool? isActive,
             [FromQuery] int? contractId,
             [FromQuery] int pageNumber = 1,
             [FromQuery] int pageSize = 10)
        {
            var filters = new List<FilterItem>();

            if (isActive.HasValue)
            {
                filters.Add(new FilterItem
                {
                    Field = "IsActive",
                    Value = isActive.Value.ToString()
                });
            }

            if (contractId.HasValue)   
            {
                filters.Add(new FilterItem
                {
                    Field = "ContractID",
                    Value = contractId.Value.ToString()
                });
            }

            var query = new GetDepartmentsListQuery
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                Filters = filters
            };

            var list = await _mediator.Send(query);
            return Ok(list);
        }
    }
}