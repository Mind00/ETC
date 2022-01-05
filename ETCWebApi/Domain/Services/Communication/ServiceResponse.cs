using ETCWebApi.Domain.models;
using ETCWebApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETCWebApi.Domain.Services.Communication
{
    public class ServiceResponse<T> {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public string Errors { get; set; }
        public T Data { get; set; }
    }
}
