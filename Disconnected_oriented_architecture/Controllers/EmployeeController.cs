using Disconnected_oriented_architecture.Dtos;
using Disconnected_oriented_architecture.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Disconnected_oriented_architecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeService _employeeservice;

        public EmployeeController(IEmployeeService employeeservice)
        {
            _employeeservice = employeeservice;
        }
        [HttpPost]
        [Route("AddEmployeeDetails")]
        public async Task<IActionResult> Post([FromBody] EmployeeDtos employeedtoobj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                var employeedata = await _employeeservice.AddEmployeeDetails(employeedtoobj);
                return StatusCode(StatusCodes.Status201Created, "employee added suceesfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
        [HttpDelete]
        [Route("DeleteEmployeeDetailsById/{empid}")]
        public async Task<IActionResult> Delete(int empid)
        {
            if (empid < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "bad request");
            }
            try
            {
                var employeedata = await _employeeservice.DeleteEmployeeDetailsById(empid);
                if (employeedata == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "employee id not found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent, "employee id deleted sucessfully");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
        [HttpGet]
        [Route("GetAllEmployeeDetails")]
        public async Task<IActionResult> GetAllEmployeeDetails()
        {
            try
            {
                var res = await _employeeservice.GetAllEmployeeDetails();
                if (res == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "employee Data not found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, res);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "internal server error");
            }
        }
        [HttpGet]
        [Route("GetEmployeeDetailsById")]
        public async Task<IActionResult> Get(int empid)
        {
            if (empid < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "bad request");
            }
            try
            {
                var res = await _employeeservice.GetEmployeeDetailsById(empid);
                if (res == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "empid not found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, res);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
        [HttpPut]
        [Route("UpdateEmployeeDetails")]
        public async Task<IActionResult> Put([FromBody] EmployeeDtos empdto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var res = await _employeeservice.UpdateEmployeeDetails(empdto);
                    return StatusCode(StatusCodes.Status201Created, "employee updated sucessfully");
                }
            }
            catch (Exception ex)

            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");

            }
        }
    }
}
