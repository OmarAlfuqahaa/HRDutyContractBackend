using HRDutyContract.DataAccess;
using HRDutyContract.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRDutyContractBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HRContractDepartmentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HRContractDepartmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/HRContractDepartment/Create
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] HRContractDepartment department)
        {
            if (department == null)
                return BadRequest("Department data is required.");

            department.IsActive ??= true;
            department.RecordDateEntry = DateTime.Now;

            _context.HRContractDepartments.Add(department);
            await _context.SaveChangesAsync();

            return Ok(department);
        }

        // POST: api/HRContractDepartment/Update
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] HRContractDepartment department)
        {
            if (department == null || department.DetailsID == 0)
                return BadRequest("Valid department data is required.");

            var existing = await _context.HRContractDepartments
                                         .FindAsync(department.DetailsID);

            if (existing == null)
                return NotFound("Department not found.");

            existing.ContractID = department.ContractID;
            existing.CompanyID = department.CompanyID;
            existing.DepartmentID = department.DepartmentID;
            existing.IsActive = department.IsActive;
            existing.RecordUpdateBy = department.RecordUpdateBy;
            existing.RecordNote = department.RecordNote;
            existing.Note = department.Note;

            await _context.SaveChangesAsync();
            return Ok(existing);
        }

        // POST: api/HRContractDepartment/Delete
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            var existing = await _context.HRContractDepartments.FindAsync(id);
            if (existing == null)
                return NotFound("Department not found.");

            // Soft delete
            existing.RecordDeleted = true;
            existing.IsActive = false;

            await _context.SaveChangesAsync();
            return Ok("Department soft-deleted successfully.");
        }
    }
}
