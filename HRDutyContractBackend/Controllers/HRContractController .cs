using HRDutyContract.Application.HRDutyContract.Commands;
using HRDutyContract.Application.HRDutyContract.Queries;
using HRDutyContract.DataAccess;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRDutyContractBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HRContractController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMediator _mediator;

        public HRContractController(ApplicationDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        // POST: api/HRContract/Manage
        [HttpPost("Manage")]
        public async Task<IActionResult> ManageContract([FromBody] ManageContractCommand command)
        {
            if (command == null || command.Contract == null)
                return BadRequest("Contract data is required.");

            var result = await _mediator.Send(command);

            if (result.status)
                return Ok(result);

            return BadRequest(result.lstError);
        }

        // GET: api/HRContract/GET CONTRACTS LIST
        [HttpGet("List")]
        public async Task<IActionResult> GetContractsList(
                [FromQuery] string? searchTerm,
                [FromQuery] bool? isActive,
                [FromQuery] int pageNumber = 1,
                [FromQuery] int pageSize = 10)
        {
            var filters = new List<FilterItem>();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                filters.Add(new FilterItem
                {
                    Field = "ContractName",
                    Value = searchTerm
                });
            }

            if (isActive.HasValue)
            {
                filters.Add(new FilterItem
                {
                    Field = "IsActive",
                    Value = isActive.Value.ToString()
                });
            }

            var query = new GetContractsListQuery
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                Filters = filters
            };

            var list = await _mediator.Send(query);
            return Ok(list);
        }



        // GET: api/HRContract/Details/
        [HttpGet("Details")]
        public async Task<IActionResult> GetContractDetails([FromQuery] GetContractDetailsByIdQuery Query)
        {
            var contract = await _mediator.Send(Query);

            if (contract == null)
                return NotFound("Contract not found");

            return Ok(contract);
        }

    }

}
