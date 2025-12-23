
using HRDutyContract.DataAccess;
using HRDutyContract.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HRDutyContract.Application.HRDutyContract.Queries;
using HRDutyContract.Application.HRDutyContract.Commands;

namespace HRDutyContractBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HRContractDutyScheduleController : ControllerBase
    {
        private readonly IMediator _mediator;
        public HRContractDutyScheduleController(IMediator mediator) => _mediator = mediator;

        [HttpGet("List")]
        public async Task<IActionResult> GetList(
            [FromQuery] int? contractId,
            [FromQuery] bool? isActive,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            var query = new GetHRContractDutyScheduleListQuery
            {
                ContractID = contractId,
                IsActive = isActive,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            var result = await _mediator.Send(query);
            return Ok(result);
        }


        [HttpPost("Manage")]
        public async Task<IActionResult> Manage([FromBody] ManageHRContractDutyScheduleCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}
