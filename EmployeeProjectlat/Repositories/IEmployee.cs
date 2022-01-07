using EmployeeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeProject.Repositories
{
  public  interface IEmployee
    {
        Task<long> CreateEmployee(Employee employee);
        Task<IList<Employee>> GetEmployees();
        Task<Employee> GetEmployeesById(long id);
        Task PutEmployee(Employee employee);
        Task<long> DeleteEmployee(long id);
        Employee GetEmpId(string EmpId);

    }
}
