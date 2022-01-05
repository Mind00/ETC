using ETCWebApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETCWebApi.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListAsync();
        Task AddAsync(User user);
        Task<User> FindByIdAsync(int id);
        Task<User> FindEmailPassword(User user);
        Task<User> FindByEmail(string email);
        void Update(User user);
        void Delete(User u);

    }
}
