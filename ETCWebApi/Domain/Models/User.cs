using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ETCWebApi.Domain.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string UserRole { get; set; }
        public bool IsActive { get; set; } 
        public DateTime JoiningDate { get; set; }
        public string PostedOn { get; set; }
        public string PostedBy { get; set; }

    }
}