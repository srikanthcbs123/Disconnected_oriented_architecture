using Disconnected_oriented_architecture.Entities;
using Disconnected_oriented_architecture.Interface;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Disconnected_oriented_architecture.Repositories
{
    public class EmployeeRepositories : IEmployeeRepositorie
    {
        string connectionString = "data source=DESKTOP-AAO14OC;integrated security=yes;Encrypt=True;TrustServerCertificate=True;initial catalog=hotelmanagement";
        //string connectionString="data source=DESKTOP-OLCB1UC;user id=sa;password=S@12345;initial catalog ="hotelmanagement";
        public EmployeeRepositories() { }
        public async  Task<bool> AddEmployeeDetails(Employee employeedetail)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Usp_AddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@empid", employeedetail.empid);
                cmd.Parameters.AddWithValue("@empname", employeedetail.empname);
                cmd.Parameters.AddWithValue("@empsalary", employeedetail.empsalary);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Employee");
            }
            return true;
        }

        public async Task<bool> DeleteEmployeeDetailsById(int empid)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Usp_DeleteEmployee", con);
                cmd.CommandType=CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empid", empid);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Employee");
            }
            return true;
        }

        public async Task<List<Employee>> GetAllEmployeeDetails()
        {
         List<Employee>  lstemp = new List<Employee>();//create empty list
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Usp_GetEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();//To store the data at ado.net side in table format we use dataset.
                dataAdapter.Fill(ds, "Employee");
                foreach(DataRow row in ds.Tables["Employee"].Rows)
                {
                    Employee emp = new Employee();
                    emp.empid = Convert.ToInt16(row["empid"]);
                    emp.empname = Convert.ToString(row["empname"]);
                    emp.empsalary = Convert.ToInt32(row["empsalary"]);
                    lstemp.Add(emp);
                }
                return lstemp;
            }
        }

        public async Task<Employee> GetEmployeeDetailsById(int empid)
        {
            Employee emp=  new Employee();
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Usp_GetEmployeeId", con);
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empid", empid);
                SqlDataAdapter da=new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Employee");
                foreach(DataRow row in ds.Tables["Employee"].Rows)
                {
                    emp.empid = Convert.ToInt16(row["empid"]);
                    emp.empname = Convert.ToString(row["empname"]);
                    emp.empsalary = Convert.ToInt32(row["empsalary"]);
                }
            }
            return emp;
        }

        public async Task<bool> UpdateEmployeeDetails(Employee employeedetail)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Usp_UpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empid",employeedetail.empid);
                cmd.Parameters.AddWithValue("@empname", employeedetail.empname);
                cmd.Parameters.AddWithValue("@empsalary", employeedetail.empsalary);
                SqlDataAdapter da= new SqlDataAdapter(cmd);
                DataSet ds=new DataSet();
                da.Fill(ds, "Employee");

            }
            return true;
        }
    }
}
