using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETCWebApi.Domain.models
{
    public class Contact
    {
        [Key]
        public int CId { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public DateTime ContactDate { get; set; }

    }
}
