namespace HRDutyContract.Application.Common.ViewModels
{
    public class EmployeeWithoutContractVm : AbstractViewModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
    }

    public class DepartmentWithEmployeesVm : AbstractViewModel
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public List<EmployeeWithoutContractVm> Employees { get; set; } = new List<EmployeeWithoutContractVm>();
    }
}
