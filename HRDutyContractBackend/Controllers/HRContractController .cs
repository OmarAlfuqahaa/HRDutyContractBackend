using HRDutyContract.DataAccess;
using HRDutyContract.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MediatR;
using HRDutyContract.Application.HRDutyContract.Queries;
using HRDutyContract.Application.HRDutyContract.Commands;

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



        /* // POST: api/HRContract/Create
         [HttpPost("Create")]
         public async Task<IActionResult> CreateContract([FromBody] HRContract contract)
         {
             if (contract == null)
                 return BadRequest("Contract data is required.");

             var maxId = await _context.HRContracts.MaxAsync(c => (int?)c.ContractID) ?? 0;
             contract.ContractID = maxId + 1;

             contract.IsActive ??= true;
             contract.RecordDateEntry = DateTime.Now;

             _context.HRContracts.Add(contract);
             await _context.SaveChangesAsync();

             return Ok(contract);
         }

         // POST: api/HRContract/Update
         [HttpPost("Update")]
         public async Task<IActionResult> UpdateContract([FromBody] HRContract contract)
         {
             if (contract == null || contract.ContractID == 0)
                 return BadRequest("Valid contract data is required.");

             var existing = await _context.HRContracts.FindAsync(contract.ContractID);
             if (existing == null)
                 return NotFound("Contract not found.");

             existing.ContractName = contract.ContractName;
             existing.ContractDate = contract.ContractDate;
             existing.ExpirationDate = contract.ExpirationDate;
             existing.IsNoExpirationDate = contract.IsNoExpirationDate;
             existing.AttendanceTime = contract.AttendanceTime;
             existing.TimeOfDeparture = contract.TimeOfDeparture;
             existing.RecordUpdateBy = contract.RecordUpdateBy;
             existing.RecordNote = contract.RecordNote;
             existing.IsActive = contract.IsActive;

             await _context.SaveChangesAsync();
             return Ok(existing);
         }

         // POST: api/HRContract/Delete
         [HttpPost("Delete")]
         public async Task<IActionResult> DeleteContract([FromBody] DeleteContractCommand command)
         {
             var contract = new HRContract { ContractID = command.ContractID };

             _context.HRContracts.Attach(contract);

             contract.RecordDeleted = "true";
             contract.IsActive = false;

             _context.Entry(contract).Property(c => c.RecordDeleted).IsModified = true;
             _context.Entry(contract).Property(c => c.IsActive).IsModified = true;

             await _context.SaveChangesAsync();

             return Ok("Contract soft-deleted successfully.");
         }*/



        // GET: api/HRContract/GET CONTRACTS LIST
        [HttpGet("List")]
        public async Task<IActionResult> GetContractsList(
                [FromQuery] string? searchTerm,
                [FromQuery] int pageNumber = 1,
                [FromQuery] int pageSize = 10)
        {
            var query = new GetContractsListQuery
            {
                SearchTerm = searchTerm,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            var list = await _mediator.Send(query);
            return Ok(list);
        }

    }


}
