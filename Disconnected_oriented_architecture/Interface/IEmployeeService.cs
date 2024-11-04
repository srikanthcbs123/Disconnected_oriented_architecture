using Disconnected_oriented_architecture.Dtos;
using Disconnected_oriented_architecture.Entities;

namespace Disconnected_oriented_architecture.Interface
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDtos>> GetAllEmployeeDetails();
        Task<EmployeeDtos> GetEmployeeDetailsById(int empid);
        Task<bool> AddEmployeeDetails(EmployeeDtos employeedetail);
        Task<bool> UpdateEmployeeDetails(EmployeeDtos employeedetail);
        Task<bool> DeleteEmployeeDetailsById(int empid);

    }
}
