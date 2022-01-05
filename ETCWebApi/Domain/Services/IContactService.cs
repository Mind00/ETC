using ETCWebApi.Domain.models;
using ETCWebApi.Domain.Services.Communication;
using ETCWebApi.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETCWebApi.Domain.Services
{
    public interface IContactService
    {
        Task<IEnumerable<Contact>> ListAsync();
        Task<ServiceResponse<Contact>> GetContactById(int id);
     
    }
}
