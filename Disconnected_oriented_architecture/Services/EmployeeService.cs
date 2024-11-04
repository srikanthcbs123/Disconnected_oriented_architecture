using Disconnected_oriented_architecture.Dtos;
using Disconnected_oriented_architecture.Entities;
using Disconnected_oriented_architecture.Interface;

namespace Disconnected_oriented_architecture.Services
{
    public class EmployeeService : IEmployeeService
    {
        IEmployeeRepositorie _employeerepositories;
        public EmployeeService(IEmployeeRepositorie employeerepositories) 
        { 
            _employeerepositories = employeerepositories;
        }
        public async Task<bool> AddEmployeeDetails(EmployeeDtos employeedetail)
        {
            Employee obj = new Employee();
            obj.empid = employeedetail.empid;
            obj.empname=employeedetail.empname;
            obj.empsalary = employeedetail.empsalary;
            await _employeerepositories.AddEmployeeDetails(obj);
            return true;
            
        }

        public async Task<bool> DeleteEmployeeDetailsById(int empid)
        {
            await _employeerepositories.DeleteEmployeeDetailsById(empid);
            return true;
        }

        public async Task<List<EmployeeDtos>> GetAllEmployeeDetails()
        {
            List<EmployeeDtos> empdtosobj = new List<EmployeeDtos>();
            var empdata=await _employeerepositories.GetAllEmployeeDetails();
            foreach(Employee emp in empdata)
            {
                EmployeeDtos empdtoobj = new EmployeeDtos();
                empdtoobj.empid = emp.empid;
                empdtoobj.empname = emp.empname;
                empdtoobj.empsalary= emp.empsalary;
                empdtosobj.Add(empdtoobj);
            }
            return empdtosobj;
        }

        public async Task<EmployeeDtos> GetEmployeeDetailsById(int empid)
        {
            var res=await _employeerepositories.GetEmployeeDetailsById(empid);
            EmployeeDtos empdto= new EmployeeDtos();
            empdto.empid = res.empid;
            empdto.empname = res.empname;
            empdto.empsalary = res.empsalary;
            return empdto;
        }

        public async Task<bool> UpdateEmployeeDetails(EmployeeDtos employeedetail)
        {
            Employee emp=new Employee();
            emp.empid=employeedetail.empid;
            emp.empname=employeedetail.empname;
            emp.empsalary=employeedetail.empsalary;
            await _employeerepositories.UpdateEmployeeDetails(emp);
            return true;
        }
    }
}
