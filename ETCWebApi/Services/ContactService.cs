using ETCWebApi.Domain.models;
using ETCWebApi.Domain.Persistence.Repositories;
using ETCWebApi.Domain.Repositories;
using ETCWebApi.Domain.Services;
using ETCWebApi.Domain.Services.Communication;
using ETCWebApi.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETCWebApi.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IUnitofWork _unitofWork;
        
        public ContactService(IContactRepository contactRepository, IUnitofWork unitofWork)
        {
            _contactRepository = contactRepository;
            _unitofWork = unitofWork;
        }

        public async Task<ServiceResponse<Contact>> GetContactById(int id)
        {
            ServiceResponse<Contact> serviceResponse = new ServiceResponse<Contact>();
            Contact contactList = await _contactRepository.FindByIdAsync(id);
            serviceResponse.Data = contactList;
            return serviceResponse;
        }

        public async Task<IEnumerable<Contact>> ListAsync()
        {
            return await _contactRepository.ListAsync();
        }
    }

}
