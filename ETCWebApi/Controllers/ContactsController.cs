//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using AutoMapper;
//using ETCWebApi.Domain.models;
//using ETCWebApi.Domain.Services;
//using ETCWebApi.Extensions;
//using ETCWebApi.Resources;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace ETCWebApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ContactsController : Controller
//    {
//        private readonly IContactService _contactService;
//        private readonly IMapper _mapper;
        
//        public ContactsController( IContactService contactService, IMapper mapper)
//        {
//            _contactService = contactService;
//            _mapper = mapper;
//        }

//        public async Task<IEnumerable<ContactResource>> GetAllContactAsync()
//        {
//            var contacts = await _contactService.ListAsync();
//            var resource = _mapper.Map<IEnumerable<Contact>, IEnumerable<ContactResource>>(contacts);
//            return resource;
//        }

//        public async Task<ContactResource>GetNoticeById(int id)
//        {
//            var contactItem = await _contactService.GetContactById(id);
//            var resource = _mapper.Map<Contact, ContactResource>(contactItem);
//            return resource;
//        }

//        public async Task<IActionResult>PostAsync([FromBody] ContactResource resource)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState.GetErrorMessages());
//            }

//            var contact = _mapper.Map<ContactResource, Contact>(resource);
//            var result = await _contactService.SaveAsync(contact);

//            if (!result.Success)
//            {
//                return BadRequest(result.Message);
//            }
//            var contactResource = _mapper.Map<Contact, ContactResource>(result.Contact);
//            return Ok(contactResource);
//        }
//    }
//}