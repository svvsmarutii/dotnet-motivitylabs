using EmployeeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeProject.Repositories
{
 public   interface IAddress
    {
        Task<int> CreateAdress(Address address);
        Task<IList<Address>> GetAddresss();
        Task<Address> GetAddresssById(int id);
        Task PutAddress(Address address);
        Task<int> DeleteAddress(int? id);
    }
}
