using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETCWebApi.Resources
{
    public class NewUserResource
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        public string contactNo { get; set; }
        [Required]
        public string UserRole { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public DateTime JoiningDate { get; set; }
    }
}
