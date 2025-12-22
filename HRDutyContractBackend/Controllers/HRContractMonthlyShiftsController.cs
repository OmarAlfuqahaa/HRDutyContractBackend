using HRDutyContract.DataAccess;
using HRDutyContract.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRDutyContractBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HRContractMonthlyShiftsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HRContractMonthlyShiftsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/HRContractMonthlyShifts/Create
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] HRContractMonthlyShifts shift)
        {
            if (shift == null)
                return BadRequest("Shift data is required.");

            shift.IsActive ??= true;
            shift.RecordDateEntry = DateTime.Now;

            _context.HRContractMonthlyShifts.Add(shift);
            await _context.SaveChangesAsync();

            return Ok(shift);
        }

        // POST: api/HRContractMonthlyShifts/Update
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] HRContractMonthlyShifts shift)
        {
            if (shift == null || shift.DetailsID == 0)
                return BadRequest("Valid shift data is required.");

            var existing = await _context.HRContractMonthlyShifts
                                         .FindAsync(shift.DetailsID);

            if (existing == null)
                return NotFound("Shift not found.");

            existing.ContractID = shift.ContractID;
            existing.CompanyID = shift.CompanyID;
            existing.Month = shift.Month;
            existing.Year = shift.Year;
            existing.TotalShifts = shift.TotalShifts;
            existing.TotalHours = shift.TotalHours;
            existing.IsActive = shift.IsActive;
            existing.RecordUpdateBy = shift.RecordUpdateBy;
            existing.RecordNote = shift.RecordNote;

            await _context.SaveChangesAsync();
            return Ok(existing);
        }

        // POST: api/HRContractMonthlyShifts/Delete
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            var existing = await _context.HRContractMonthlyShifts.FindAsync(id);
            if (existing == null)
                return NotFound("Shift not found.");

            // Soft delete
            existing.RecordDeleted = true;
            existing.IsActive = false;

            await _context.SaveChangesAsync();
            return Ok("Shift soft-deleted successfully.");
        }
    }
}