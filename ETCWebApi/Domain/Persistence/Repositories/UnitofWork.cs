using ETCWebApi.Domain.Persistence.Contexts;
using ETCWebApi.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETCWebApi.Domain.Persistence.Repositories
{
    public class UnitofWork : IUnitofWork
    {
        private readonly AppDbContext _context;

        public UnitofWork(AppDbContext context)
        {
            _context = context;
        }
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
