using ETCWebApi.Domain.models;
using ETCWebApi.Domain.Models;
using ETCWebApi.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETCWebApi.Domain.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> ListAsync();
        Task<ServiceResponse<User>> GetUserById(int id);
        Task<User> FindByEmail(string email);
        Task<ServiceResponse<User>> SaveAsync(User user);
        Task<ServiceResponse<User>> UpdateAsync(int id, User user);
        Task<ServiceResponse<User>> DeleteAsync(int id);
    }
}
