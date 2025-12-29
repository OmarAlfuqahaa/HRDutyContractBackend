using HRDutyContract.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace HRDutyContract.Application.Common.Interfaces
{
    public interface IHRContext
    {
        public DbSet<HRContract> HRContracts { get; set; }
        public DbSet<HRContractDepartment> HRContractDepartments { get; set; }
        public DbSet<HRContractDutySchedule> HRContractDutySchedules { get; set; }
        public DbSet<HRContractEmployees> HRContractEmployees { get; set; }
        public DbSet<HRContractMonthlyShifts> HRContractMonthlyShifts { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        DbSet<Users> Users { get; set; }



    }

}
