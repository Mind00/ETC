using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ETCWebApi.Domain.Models;
using ETCWebApi.Domain.Services;
using ETCWebApi.Extensions;
using ETCWebApi.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETCWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<UserResource>> GetAllUserAsync()
        {
            var users = await _userService.ListAsync();
            var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
            return resources;
            
        }

        [HttpGet("{id}")]
        public async Task<UserResource> GetUserItem(int id)
        {
            var userItem = await _userService.GetUserById(id);
            var resource = _mapper.Map<User, UserResource>(userItem.Data);
            return resource;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] NewUserResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var user = _mapper.Map<NewUserResource, User>(resource);
            var result = await _userService.SaveAsync(user);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var userResource = _mapper.Map<User, UserResource>(result.Data);
            return Ok(userResource);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] NewUserResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var user = _mapper.Map<NewUserResource, User>(resource);
            var result = await _userService.UpdateAsync(id, user);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var userResource = _mapper.Map<User, UserResource>(result.Data);
            return Ok(userResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _userService.DeleteAsync(id);

            if (!result.IsSuccess)
                return BadRequest(result.Message);
            return Ok(result.Message);
        }
    }
}