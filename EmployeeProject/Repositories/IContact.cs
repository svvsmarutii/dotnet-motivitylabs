using EmployeeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeProject.Repositories
{
   public interface IContact
    {
        Task<int> CreateContact(Contact contact);
        Task<IList<Contact>> GetContacts();
        Task<Contact> GetContactsById(int id);
        Task PutContact(Contact contact);
        Task<int> DeleteContact(int? id);
    }
}
