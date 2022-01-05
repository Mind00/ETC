using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETCWebApi.Resources
{
    public class UserResource
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string UserRole { get; set; }
        public bool IsActive { get; set; }
        public DateTime JoiningDate { get; set; }
    }
}
