using ETCWebApi.Domain.models;
using ETCWebApi.Domain.Models.Query;
using ETCWebApi.Domain.Persistence.Contexts;
using ETCWebApi.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETCWebApi.Domain.Persistence.Repositories
{
    public class NoticeRepository : BaseRepository, INoticeRepository
    {
        public NoticeRepository(AppDbContext context): base(context) { }

        public async Task<IEnumerable<Notice>> ListAsync()
        {
            return await _context.Notices.ToListAsync();
           
        }
        public async Task AddAsync(Notice notice)
        {
            await _context.Notices.AddAsync(notice);
        }
        public async Task<Notice> FindByIdAsync(int id)
        {
            return await _context.Notices.FindAsync(id);
        }

        public void Update(Notice notice)
        {
            _context.Notices.Update(notice);
        }

        public void Delete(Notice notice)
        {
            _context.Notices.Remove(notice);
        }
    }
}
