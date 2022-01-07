using EmployeeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EmployeeProject.Repositories
{
    public class ContactRepository : IContact
    {
        readonly EmployeeContext _context;
        public ContactRepository(EmployeeContext context)
        {
            _context = context;
        }

        public async Task<int> CreateContact(Contact contact)
        {

            if (_context != null)
            {
                await _context.Contacts.AddAsync(contact);
                await _context.SaveChangesAsync();

                return contact.Id;
            }
            return 0;
        }

        public async Task<int> DeleteContact(int? id)
        {
            int result1 = 0;
            if (_context != null)
            {
                var eid = _context.Contacts.FirstOrDefault(s => s.Id == id);
                if (eid != null)
                {
                    _context.Contacts.Remove(eid);
                    var result = await _context.SaveChangesAsync();
                    return result;
                }

            }
            return result1;
        }

        public async Task<IList<Contact>> GetContacts()
        {
            if (_context != null)
            {
                return await _context.Contacts.ToListAsync();
            }
            return null;
        }
        public Task<Contact> GetContactsById(int id)
        {
            if (_context != null)
            {
                return _context.Contacts.FirstAsync(s => s.Id == id);
            }

            return null;
        }

        public async Task PutContact(Contact contact)
        {

            _context.Contacts.Update(contact);
            await _context.SaveChangesAsync();

        }
    }
}
