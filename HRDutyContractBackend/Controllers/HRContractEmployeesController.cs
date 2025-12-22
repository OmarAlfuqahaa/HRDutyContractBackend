using HRDutyContract.DataAccess;
using HRDutyContract.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRDutyContractBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HRContractEmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HRContractEmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/HRContractEmployees/Create
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] HRContractEmployees employee)
        {
            if (employee == null)
                return BadRequest("Employee data is required.");

            employee.IsActive ??= true;
            employee.RecordDateEntry = DateTime.Now;

            _context.HRContractEmployees.Add(employee);
            await _context.SaveChangesAsync();

            return Ok(employee);
        }

        // POST: api/HRContractEmployees/Update
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] HRContractEmployees employee)
        {
            if (employee == null || employee.DetailsID == 0)
                return BadRequest("Valid employee data is required.");

            var existing = await _context.HRContractEmployees
                                         .FindAsync(employee.DetailsID);

            if (existing == null)
                return NotFound("Employee not found.");

            existing.ContractID = employee.ContractID;
            existing.CompanyID = employee.CompanyID;
            existing.UserID = employee.UserID;
            existing.IsActive = employee.IsActive;
            existing.RecordUpdateBy = employee.RecordUpdateBy;
            existing.RecordNote = employee.RecordNote;

            existing.OvertimeTypeID_NormalDuty = employee.OvertimeTypeID_NormalDuty;
            existing.Multiplier_NormalDuty = employee.Multiplier_NormalDuty;
            existing.OvertimeTypeID_InVacation = employee.OvertimeTypeID_InVacation;
            existing.Multiplier_InVacation = employee.Multiplier_InVacation;
            existing.Multiplier_NormalDuty_FromRange = employee.Multiplier_NormalDuty_FromRange;
            existing.Multiplier_NormalDuty_ToRange = employee.Multiplier_NormalDuty_ToRange;
            existing.NextMultiplier_NormalDuty = employee.NextMultiplier_NormalDuty;
            existing.NextMultiplier_NormalDuty_FromRange = employee.NextMultiplier_NormalDuty_FromRange;
            existing.NextMultiplier_NormalDuty_ToRange = employee.NextMultiplier_NormalDuty_ToRange;

            await _context.SaveChangesAsync();
            return Ok(existing);
        }

        // POST: api/HRContractEmployees/Delete
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            var existing = await _context.HRContractEmployees.FindAsync(id);
            if (existing == null)
                return NotFound("Employee not found.");

            // Soft delete
            existing.RecordDeleted = true;
            existing.IsActive = false;

            await _context.SaveChangesAsync();
            return Ok("Employee soft-deleted successfully.");
        }
    }
}
