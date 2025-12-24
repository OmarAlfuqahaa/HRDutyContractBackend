using HRDutyContract.Application.HRDutyContract.Commands;
using HRDutyContract.DataAccess;
using HRDutyContract.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            [FromBody] ManageHRContractDepartmentCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.status)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
