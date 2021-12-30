using EmployeeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EmployeeProject.Repositories
{
    public class AddressRepository : IAddress
    {
        readonly EmployeeContext _context;
        public AddressRepository(EmployeeContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAdress(Address address)
        {

            if (_context != null)
            {
                await _context.Addresses.AddAsync(address);
                await _context.SaveChangesAsync();

                return address.Id;
            }
            return 0;
        }

        public async Task<int> DeleteAddress(int? id)
        {
            int result1 = 0;
            if (_context != null)
            {
                var eid = _context.Addresses.FirstOrDefault(s => s.Id == id);
                if (eid != null)
                {
                    _context.Addresses.Remove(eid);
                    var result = await _context.SaveChangesAsync();
                    return result;
                }

            }
            return result1;
        }

        public async Task<IList<Address>> GetAddresss()
        {
            if (_context != null)
            {
                return await _context.Addresses.ToListAsync();
            }
            return null;
        }
        public Task<Address> GetAddresssById(int id)
        {
            if (_context != null)
            {
                return _context.Addresses.FirstAsync(s => s.Id == id);
            }

            return null;
        }

        public async Task PutAddress(Address address)
        {

            _context.Addresses.Update(address);
            await _context.SaveChangesAsync();

        }
    }
}
