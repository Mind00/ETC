using ETCWebApi.Domain.models;
using ETCWebApi.Domain.Models.Query;
using ETCWebApi.Domain.Repositories;
using ETCWebApi.Domain.Services;
using ETCWebApi.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETCWebApi.Services
{
    public class NoticeService : INoticeService
    {
        private readonly INoticeRepository _noticeRepository;
        private readonly IUnitofWork _unitofWork;

        public NoticeService(INoticeRepository noticeRepository, IUnitofWork unitofWork)
        {
            this._noticeRepository = noticeRepository;
            _unitofWork = unitofWork;
        }

        public async Task<IEnumerable<Notice>> ListAsync()
        {
            return await _noticeRepository.ListAsync();
        }

        public async Task<Notice> GetNoticeById(int id)
        {
            return await _noticeRepository.FindByIdAsync(id);
        }


        public async Task<ServiceResponse<Notice>> SaveAsync(Notice notice)
        {
            try
            {
                await _noticeRepository.AddAsync(notice);
                await _unitofWork.CompleteAsync();
                return new ServiceResponse<Notice> { 
                    Message = "Notice created Successfully!!",
                    IsSuccess = true,
                    Data = notice
                };
            }
            catch(Exception ex)
            {
                return new ServiceResponse<Notice>
                {
                    //Message = "An error occured when saving the notice",
                    IsSuccess = false,
                    Errors = ex.Message,
                    Data = null
                }; 
            }
        }
        public async Task<ServiceResponse<Notice>> UpdateAsync(int id, Notice notice)
        {
            var existingNotice = await _noticeRepository.FindByIdAsync(id);

            if (existingNotice == null)
                return new ServiceResponse<Notice> {
                    Message = "Notice not found!!",
                    IsSuccess = false,
                    Data = null,
                }; 

            existingNotice.IssuedDate = notice.IssuedDate;
            existingNotice.Title = notice.Title;
            existingNotice.Description = notice.Description;

            try
            {
                _noticeRepository.Update(existingNotice);
                await _unitofWork.CompleteAsync();

                return new ServiceResponse<Notice> { 
                    IsSuccess = true,
                    Data = existingNotice
                }; 
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ServiceResponse<Notice> { 
                    Message = "An error occurred when updating the notice!!",
                    IsSuccess = false,
                    Errors = ex.Message
                };
            }
        }

        public async Task<ServiceResponse<Notice>> DeleteAsync(int id)
        {
            var existingNotice = await _noticeRepository.FindByIdAsync(id);

            if (existingNotice == null)
                return new ServiceResponse<Notice>{
                    Message = "Notice not found",
                    IsSuccess = false,
                    Data = null,
                };

            try
            {
                _noticeRepository.Delete(existingNotice);
                await _unitofWork.CompleteAsync();

                return new ServiceResponse<Notice> { 
                    Message = "Notice deleted successfully",
                    IsSuccess = true,
                }; 
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ServiceResponse<Notice> { 
                
                    Message= "An error occurred when deleting the notice!!",
                    IsSuccess = false,
                    Errors = ex.Message
                }; 
            }
        }
    }
}
