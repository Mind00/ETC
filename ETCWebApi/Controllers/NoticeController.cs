using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ETCWebApi.Domain.models;
using ETCWebApi.Domain.Models.Query;
using ETCWebApi.Domain.Services;
using ETCWebApi.Extensions;
using ETCWebApi.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETCWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticeController : Controller
    {
        private readonly INoticeService _noticeService;
        private readonly IMapper _mapper;

        public NoticeController(INoticeService service, IMapper mapper)
        {
            _noticeService = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<NoticeResource>> GetAllNoticeAsync()
        {
            var notices = await _noticeService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Notice>, IEnumerable<NoticeResource>>(notices);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<NoticeResource> GetNoticeItem(int id)
        {
            var noticeItem = await _noticeService.GetNoticeById(id);
            var resource = _mapper.Map<Notice, NoticeResource>(noticeItem);
            return resource;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] NewNoticeSavingResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var notice = _mapper.Map<NewNoticeSavingResource, Notice>(resource);
            var result = await _noticeService.SaveAsync(notice);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var noticeResource = _mapper.Map<Notice, NoticeResource>(result.Data);
            return Ok(noticeResource);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] NewNoticeSavingResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var notice = _mapper.Map<NewNoticeSavingResource, Notice>(resource);
            var result = await _noticeService.UpdateAsync(id, notice);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var noticeResource = _mapper.Map<Notice, NoticeResource>(result.Data);
            return Ok(noticeResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _noticeService.DeleteAsync(id);

            if (!result.IsSuccess)
                return BadRequest(result.Message);
            return Ok(result.Message);
        }
    }
}