using Microsoft.EntityFrameworkCore;
using HRDutyContract.Domain.Entities;
using HRDutyContract.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace HRDutyContract.DataAccess
{
    public class ApplicationDbContext : DbContext, IHRContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<HRContract> HRContracts { get; set; }
        public DbSet<HRContractDepartment> HRContractDepartments { get; set; }
        public DbSet<HRContractDutySchedule> HRContractDutySchedules { get; set; }
        public DbSet<HRContractEmployees> HRContractEmployees { get; set; }
        public DbSet<HRContractMonthlyShifts> HRContractMonthlyShifts { get; set; }


        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /*modelBuilder.Entity<HRContractDepartment>().ToTable("HR_Contract_Departments", "dbo");
            modelBuilder.Entity<HRContractDutySchedule>().ToTable("HR_Contract_Duty_Schedule", "dbo");
            modelBuilder.Entity<HRContractEmployees>().ToTable("HR_Contract_Employees", "dbo");
            modelBuilder.Entity<HRContractMonthlyShifts>().ToTable("HR_Contract_Monthly_Shifts", "dbo");*/

            modelBuilder.Entity<HRContract>().HasKey(x=> new {x.ContractID, x.CompanyID});

        }
    }
}
