using HRDutyContract.Application.HRDutyContract.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using HRDutyContract.Application.HRDutyContract.Commands;


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
        [HttpPost("Manage")]
        public async Task<IActionResult> ManageMonthlyShift([FromBody] ManageHRContractMonthlyShiftCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }



        // GET: api/HRContractMonthlyShifts/List
        [HttpGet("List")]
        public async Task<IActionResult> GetMonthlyShiftsList([FromQuery] bool? isActive, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var query = new GetMonthlyShiftsListQuery
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                Filters = new List<FilterItem>()
            };

            if (isActive.HasValue)
            {
                query.Filters.Add(new FilterItem
                {
                    Field = "IsActive",
                    Value = isActive.Value.ToString()
                });
            }

            var result = await _mediator.Send(query);
            return Ok(result);
        }

    }
}