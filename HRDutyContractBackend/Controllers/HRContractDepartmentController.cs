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

        [HttpPost("ManageDepartment")]
        public async Task<IActionResult> Manage(
                [FromBody] ManageHRContractDepartmentsCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.status)
                return BadRequest(result);

            return Ok(result);
        }


        [HttpGet("ListDepartment")]
        public async Task<IActionResult> GetDepartmentsList(
            [FromQuery] bool? isActive,
            [FromQuery] int? contractId,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            var query = new GetDepartmentsListQuery
            {
                IsActive = isActive,
                ContractId = contractId,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return Ok(await _mediator.Send(query));
        }

    }
}