using ETCWebApi.Domain.models;
using ETCWebApi.Domain.Models.Query;
using ETCWebApi.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETCWebApi.Domain.Services
{
    public interface INoticeService
    {
        Task<IEnumerable<Notice>> ListAsync();
        Task<Notice> GetNoticeById(int id);
        Task<ServiceResponse<Notice>> SaveAsync(Notice notice);
        Task<ServiceResponse<Notice>> UpdateAsync(int id, Notice notice);
        Task<ServiceResponse<Notice>> DeleteAsync(int id);
    }
}
