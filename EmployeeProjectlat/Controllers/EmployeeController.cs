using EmployeeProject.Models;
using EmployeeProject.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EmployeeProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employee;
        //private readonly ILogger<EmployeeController> //_ilogger;
        public EmployeeController(IEmployee employee)//, ILogger<EmployeeController> ilogger)
        {
            _employee = employee;
            //_ilogger = ilogger;
        }  
        [HttpGet]
        [Route("GetEmployee")]
        public async Task<IActionResult> GetEmployee()
        {
            try
            {
                //_ilogger.LogInformation("EmployeeController  GetEmployee Method Started");
                var result = await _employee.GetEmployees();
                if (result == null)
                    return NotFound();
                //_ilogger.LogInformation("EmployeeController  GetEmployee Method Ended");
                return Ok(result);
            }
            catch (Exception ex)
            {
                //_ilogger.LogError("Employee Repository GetEmployee Method Log Error" + ex.Message);
            }
            return BadRequest();
        }
        [HttpGet]
        [Route("GetEmployeeById")]
        public async Task<IActionResult> GetEmployeeById(long id)
        {
            try
            {
                //_ilogger.LogInformation("EmployeeController  GetEmployeeById Method Started");
                var result = await _employee.GetEmployeesById(id);
                //_ilogger.LogInformation("EmployeeController  GetEmployeeById Method Ended");
                if (result == null)                  
                    return NotFound();
                else
                    return Ok(result);
            }
            catch (Exception ex)
            {
                //_ilogger.LogError("Employee Repository GetEmployeeById Method Log Error" + ex.Message);
            }
            return BadRequest();
        }
        [HttpPost]
        [Route("CreateEmployee")]
        public async Task<IActionResult> CreateEmployee([FromBody] Employee employee)
        {
            var getempid = _employee.GetEmpId(employee.EmpId);
            if (ModelState.IsValid && getempid==null)
            {
                try
                {                          
                        //_ilogger.LogInformation("EmployeeController  CreateEmployee Method Started");
                        var Result = await _employee.CreateEmployee(employee);
                        //_ilogger.LogInformation("EmployeeController  CreateEmployee Method Ended");
                        if (Result > 0)
                            return Ok(Result);
                        else
                            return NotFound();
                }
                catch (Exception ex)
                {
                    //_ilogger.LogError("Employee Repository CreateEmployee Method Log Error" + ex.Message);
                }
            }
            return BadRequest();

        }
        [HttpDelete]
        [Route("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(long id)
        {
            try
            {
                //_ilogger.LogInformation("EmployeeController  DeleteEmployee Method Started");
                var result = await _employee.DeleteEmployee(id);
                //_ilogger.LogInformation("EmployeeController  DeleteEmployee Method Ended");
                if (result == 0)
                    return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                //_ilogger.LogError("Employee Repository DeleteEmployee Method Log Error" + ex.Message);
            }
            return BadRequest();
        }
        [HttpPut]
        [Route("PutEmployee")]
        public async Task<IActionResult> PutEmployee([FromBody] Employee employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //_ilogger.LogInformation("EmployeeController  PutEmployee Method Started");
                    await _employee.PutEmployee(employee);
                    //_ilogger.LogInformation("EmployeeController  PutEmployee Method Ended");
                    return Ok();
                }
                catch (Exception ex)
                {
                    //_ilogger.LogError("Employee Repository PutEmployee Method Log Error" + ex.Message);
                }
            }
            return BadRequest();
        }


    }
}
