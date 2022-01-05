using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETCWebApi.Domain.models;
using ETCWebApi.Domain.Models;
using ETCWebApi.Domain.Persistence.Contexts;
using ETCWebApi.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ETCWebApi.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public void Delete(User u)
        {
            _context.Users.Remove(u);
        }

        public async Task<User> FindByEmail(string email)
        {
            return await _context.Users.SingleOrDefaultAsync(u=>u.Email == email);
        }

        public async Task<User> FindByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> FindEmailPassword(User user)
        {
            return await _context.Users.FindAsync(user);
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }
    }
}