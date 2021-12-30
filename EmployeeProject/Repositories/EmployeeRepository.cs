using EmployeeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EmployeeProject.Repositories
{
    public class EmployeeRepository : IEmployee
    {
       // private readonly EmployeeContext context;
        //private readonly ILogger //_ilogger;
        private EmployeeContext context;

        //public EmployeeRepository(EmployeeContext context)//, ILogger<EmployeeRepository> logger)
        //{
        //    context = context;
        //    ////_ilogger = logger;
        //}

        public EmployeeRepository(EmployeeContext context)
        {
            this.context = context;
        }

        public async Task<long> CreateEmployee(Employee employee)
        {
            try
            {
                if (context != null)
                {
                    //_ilogger.LogInformation("Employee Repository CreateEmployee Method Started");
                    await context.Employees.AddAsync(employee);
                    await context.SaveChangesAsync();
                    //_ilogger.LogInformation("Employee Repository CreateEmployee Method Ended ");
                    return employee.Id;
                }

            }
            catch (Exception ex)
            {

                //_ilogger.LogError("Employee Repository CreateEmployee Method Log Error" + ex.Message);
            }

            return 0;
        }

        public async Task<long> DeleteEmployee(long id)
        {

            try
            {
                if (context != null)
                {
                    //_ilogger.LogInformation("Employee Repository DeleteEmployee Method Started");
                    var eid = context.Employees.FirstOrDefault(s => s.Id == id);
                    if (eid != null)
                    {
                        context.Employees.Remove(eid);
                        var result = await context.SaveChangesAsync();
                        return result;

                    }
                    //_ilogger.LogInformation("Employee Repository DeleteEmployee Ended Started");
                }
            }
            catch (Exception ex)
            {

                //_ilogger.LogError("Employee Repository DeleteEmployee Method Log Error" + ex.Message);
            }

            return id;
        }     
        public async Task<IList<Employee>> GetEmployees()
        {
            try
            {

                if (context != null)
                {
                    //_ilogger.LogInformation("Employee Repository GetEmployees Method Started");            
                   var result=await  context.Employees.ToListAsync();
                    return result;
                }
                //_ilogger.LogInformation("Employee Repository GetEmployees Method Ended");
            }

            catch (Exception ex)
            {

                //_ilogger.LogError("Employee Repository GetEmployees Method Log Error" + ex.Message);
            }

            return null;
        }
        public Task<Employee> GetEmployeesById(long id)
        {
            try
            {
                //_ilogger.LogInformation("Employee Repository GetEmployeesById Method Started");
                if (context != null)
                    return context.Employees.FirstAsync(s => s.Id == id);
                //_ilogger.LogInformation("Employee Repository GetEmployeesById Method Ended");
            }
            catch (Exception ex)
            {
                //_ilogger.LogError("Employee Repository GetEmployeesById Method Log Error" + ex.Message);
            }

            return null;
        }

        public async Task PutEmployee(Employee employee)
        {
            try
            {
                //_ilogger.LogInformation("Employee Repository PutEmployee Method Started");
                context.Employees.Update(employee);
                await context.SaveChangesAsync();
                //_ilogger.LogInformation("Employee Repository PutEmployee Method Ended");
            }
            catch (Exception ex)
            {

                //_ilogger.LogError("Employee Repository PutEmployee Method Log Error" + ex.Message);
            }
        }

        public Employee GetEmpId(string EmpId)
        {
            try
            {
                //_ilogger.LogInformation("Employee Repository GetEmployeesById Method Started");
                if (context != null)
                {
                    var eid = context.Employees.FirstOrDefault(s => s.EmpId == EmpId);
                    //_ilogger.LogInformation("Employee Repository GetEmployeesById Method Ended");
                    return eid;
                }

            }
            catch (Exception ex)
            {
                //_ilogger.LogError("Employee Repository GetEmployeesById Method Log Error" + ex.Message);
            }
            return null;
        }
    }
}
