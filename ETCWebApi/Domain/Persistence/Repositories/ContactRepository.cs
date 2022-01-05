using ETCWebApi.Domain.models;
using ETCWebApi.Domain.Persistence.Contexts;
using ETCWebApi.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETCWebApi.Domain.Persistence.Repositories
{
    public class ContactRepository : IContactRepository
    {

        private readonly AppDbContext _context;
        
        public ContactRepository( AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contact>> ListAsync()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task AddAsync(Contact contact)
        {
            await _context.Contacts.AddAsync(contact);
        }

        public async Task<Contact> FindByIdAsync(int id)
        {
            return await _context.Contacts.FindAsync(id);
        }
    }
}
