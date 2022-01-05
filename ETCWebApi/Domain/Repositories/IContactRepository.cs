using ETCWebApi.Domain.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETCWebApi.Domain.Repositories
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> ListAsync();
        Task AddAsync(Contact contact);
        Task<Contact> FindByIdAsync(int id);
    }
}
