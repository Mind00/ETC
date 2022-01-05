using ETCWebApi.Domain.models;
using ETCWebApi.Domain.Models.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETCWebApi.Domain.Repositories
{
    public interface INoticeRepository
    {
        Task<IEnumerable<Notice>> ListAsync();
        Task AddAsync(Notice notice);
        Task<Notice> FindByIdAsync(int id);
        void Update(Notice notice);
        void Delete(Notice notice);
    }
}
