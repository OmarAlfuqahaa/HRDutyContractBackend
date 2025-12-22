using HRDutyContract.DataAccess;
using HRDutyContract.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRDutyContractBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HRContractDutyScheduleController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HRContractDutyScheduleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/HRContractDutySchedule/Create
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] HRContractDutySchedule schedule)
        {
            if (schedule == null)
                return BadRequest("Schedule data is required.");

            schedule.IsActive ??= true;
            schedule.RecordDateEntry = DateTime.Now;

            _context.HRContractDutySchedules.Add(schedule);
            await _context.SaveChangesAsync();

            return Ok(schedule);
        }

        // POST: api/HRContractDutySchedule/Update
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] HRContractDutySchedule schedule)
        {
            if (schedule == null || schedule.DetailsID == 0)
                return BadRequest("Valid schedule data is required.");

            var existing = await _context.HRContractDutySchedules
                                         .FindAsync(schedule.DetailsID);

            if (existing == null)
                return NotFound("Schedule not found.");

            existing.ContractID = schedule.ContractID;
            existing.CompanyID = schedule.CompanyID;
            existing.ShiftTypeID = schedule.ShiftTypeID;
            existing.FromTime = schedule.FromTime;
            existing.ToTime = schedule.ToTime;
            existing.ShiftTotalHours = schedule.ShiftTotalHours;
            existing.Multiplier = schedule.Multiplier;
            existing.InCall_Multiplier = schedule.InCall_Multiplier;
            existing.OnCall_Multiplier = schedule.OnCall_Multiplier;
            existing.Amount = schedule.Amount;
            existing.BaseLine = schedule.BaseLine;
            existing.AllowanceTypeID = schedule.AllowanceTypeID;
            existing.AllowanceTypeID2 = schedule.AllowanceTypeID2;
            existing.IsWithSalaryCalculate = schedule.IsWithSalaryCalculate;
            existing.ShiftBehaviorID = schedule.ShiftBehaviorID;
            existing.MonthlyMaxShifts = schedule.MonthlyMaxShifts;
            existing.HolidayMultiplier = schedule.HolidayMultiplier;
            existing.HolidayInCall_Multiplier = schedule.HolidayInCall_Multiplier;
            existing.HolidayOnCall_Multiplier = schedule.HolidayOnCall_Multiplier;
            existing.IsActive = schedule.IsActive;
            existing.RecordUpdateBy = schedule.RecordUpdateBy;
            existing.RecordNote = schedule.RecordNote;
            existing.Note = schedule.Note;

            await _context.SaveChangesAsync();
            return Ok(existing);
        }

        // POST: api/HRContractDutySchedule/Delete
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            var existing = await _context.HRContractDutySchedules.FindAsync(id);
            if (existing == null)
                return NotFound("Schedule not found.");

            // Soft delete
            existing.RecordDeleted = true;
            existing.IsActive = false;

            await _context.SaveChangesAsync();
            return Ok("Schedule soft-deleted successfully.");
        }
    }
}
