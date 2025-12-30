using HRDutyContract.Application.HRDutyContract.Commands;
using HRDutyContract.Application.HRDutyContract.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace HRDutyContractBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HRContractMonthlyShiftsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HRContractMonthlyShiftsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST: api/HRContractMonthlyShifts/Manage
        [HttpPost("ManageMonthlyShifts")]
        public async Task<IActionResult> ManageMonthlyShift(
                [FromBody] ManageHRContractMonthlyShiftCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }




        // GET: api/HRContractMonthlyShifts/List
        [HttpGet("ListMonthlyShifts")]
        public async Task<IActionResult> GetMonthlyShiftsList(
                [FromQuery] bool? isActive,
                [FromQuery] int? contractId,
                [FromQuery] int pageNumber = 1,
                [FromQuery] int pageSize = 10)
        {
            var query = new GetMonthlyShiftsListQuery
            {
                IsActive = isActive,
                ContractId = contractId,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            var result = await _mediator.Send(query);
            return Ok(result);
        }


    }
}