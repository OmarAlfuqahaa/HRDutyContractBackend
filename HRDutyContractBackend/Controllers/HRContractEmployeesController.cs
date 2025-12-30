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

        [HttpPost("ManageEmployees")]
        public async Task<IActionResult> Manage([FromBody] ManageHRContractEmployeesCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }




        [HttpGet("ListEmployees")]
        public async Task<IActionResult> GetEmployeesList(
                [FromQuery] bool? isActive,
                [FromQuery] int? contractId,
                [FromQuery] int pageNumber = 1,
                [FromQuery] int pageSize = 10)
        {
            var query = new GetEmployeesListQuery
            {
                IsActive = isActive,
                ContractId = contractId,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            var result = await _mediator.Send(query);
            return Ok(result);
        }



        // GET: api/Users/WithoutContracts?companyId
        [HttpGet("WithoutContractsEmployees")]
        public async Task<IActionResult> GetEmployeesWithoutContracts(
                [FromQuery] int? companyId,
                [FromQuery] string? searchTerm)
        {
            var query = new GetEmployeesWithoutContractsQuery
            {
                CompanyId = companyId,
                SearchTerm = searchTerm
            };

            var result = await _mediator.Send(query);
            return Ok(result);
        }



    }
}
