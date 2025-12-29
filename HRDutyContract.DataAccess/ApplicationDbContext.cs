  using Microsoft.EntityFrameworkCore;
using HRDutyContract.Domain.Entities;
using HRDutyContract.Application.Common.Interfaces;


namespace HRDutyContract.DataAccess
{
    public class ApplicationDbContext : DbContext, IHRContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }   
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

            modelBuilder.Entity<HRContract>().HasKey(x => new { x.ContractID, x.CompanyID });
            modelBuilder.Entity<HRContractDepartment>().HasKey(x => new { x.DetailsID, x.ContractID, x.CompanyID });
            modelBuilder.Entity<HRContractDutySchedule>().HasKey(x => new { x.DetailsID, x.ContractID, x.CompanyID });
            modelBuilder.Entity<HRContractEmployees>().HasKey(x => new { x.DetailsID, x.ContractID, x.CompanyID });
            modelBuilder.Entity<HRContractMonthlyShifts>().HasKey(x => new { x.DetailsID, x.ContractID, x.CompanyID });
            modelBuilder.Entity<Users>().HasKey(x => new { x.UserID, x.CompanyID });




        }
    }
}