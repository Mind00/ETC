using ETCWebApi.Domain.Models;
using ETCWebApi.Domain.Repositories;
using ETCWebApi.Domain.Security.Hashing;
using ETCWebApi.Domain.Services;
using ETCWebApi.Domain.Services.Communication;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ETCWebApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitofWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;

        public UserService(IUserRepository userRepository, IUnitofWork unitOfWork, IPasswordHasher passwordHasher)
        {
            _passwordHasher = passwordHasher;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public async Task<User> FindByEmail(string email)
        {
            return await _userRepository.FindByEmail(email);
        }

        public async Task<ServiceResponse<User>> DeleteAsync(int id)
        {
            var existingUser = await _userRepository.FindByIdAsync(id);

            if (existingUser == null)
                return new ServiceResponse<User>
                {
                    Message = "User not found!!",
                    IsSuccess = false,
                    Data = null
                };

            try	
            {
                _userRepository.Delete(existingUser);
                await _unitOfWork.CompleteAsync();

                return new ServiceResponse<User> { 
                    Message = "User deleted successfully!!",
                    IsSuccess = true,
                };
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ServiceResponse<User>{
                    Message = "An error occurred while deleting the notice!!",
                    IsSuccess = false,
                    Errors = ex.Message
                };
            }
        }

        public async Task<ServiceResponse<User>> GetUserById(int id)
        {
          var existingUser =  await _userRepository.FindByIdAsync(id); 
            if(existingUser == null)
            {
                return new ServiceResponse<User>
                {
                    Message = " User not found!!",
                    IsSuccess = false,
                };
            }
            else
            {
                return new ServiceResponse<User>
                {
                    IsSuccess = true,
                    Data = existingUser
                };
            }
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _userRepository.ListAsync();
        }

        public async Task<ServiceResponse<User>> SaveAsync(User user)
        {
            try
            {
                var existingUser = await _userRepository.FindByEmail(user.Email);
                if (existingUser != null)
                {
                    return new ServiceResponse<User> {
                    Message = "Email already taken",
                    IsSuccess = false,
                    };
                    //var response = new { 
                    //isSuccess= false,
                    //type = "error",
                    //message = "Email already taken.",
                    //data = ""
                    //};
                    //return Ok(JsonConvert.SerializeObject(response));
                }
                user.Password = _passwordHasher.HashPassword(user.Password);
                user.ConfirmPassword = user.Password;
                user.PostedOn = new DateTime().ToString();
                await _userRepository.AddAsync(user);
                await _unitOfWork.CompleteAsync();
                return new ServiceResponse<User> { 
                        Message = "User created successfully!!", 
                        IsSuccess = true,
                        Data = user
                };
            } 
            catch(Exception ex)
            {
                return new ServiceResponse<User> {
                    Message = "An error occured while saving the user!!",
                    IsSuccess = false,
                    Errors = ex.Message
                };
            }
        }

        public async Task<ServiceResponse<User>> UpdateAsync(int id, User user)
        {
            var existingUser = await _userRepository.FindByIdAsync(id);
            if(existingUser == null)
            {
                return new ServiceResponse<User> { 
                    Message = "User not found",
                    IsSuccess = false,
                };
            }
            existingUser.FullName = user.FullName;
            existingUser.Address = user.Address;
            existingUser.ContactNo = user.ContactNo;
            existingUser.Email = user.Email;
            existingUser.IsActive = user.IsActive;
            existingUser.UserRole = user.UserRole;
            existingUser.JoiningDate = user.JoiningDate;
            try
            {
                _userRepository.Update(existingUser);
                await _unitOfWork.CompleteAsync();
                return new ServiceResponse<User> {
                    Message = "User updated successfully!!",
                    IsSuccess= false,
                    Data = user
                };
            } catch(Exception ex)
            {
                return new ServiceResponse<User>{
                    Message = "An error occured while updating the user",
                    IsSuccess = false,
                    Errors =  ex.Message
                };
            }
        }
    }
}