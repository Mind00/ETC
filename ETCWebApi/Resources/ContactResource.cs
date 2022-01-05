using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETCWebApi.Resources
{
    public class ContactResource
    {
        [Key]
        public int cId { get; set; }
        public string email { get; set; }
        public string comment { get; set; }
        public DateTime contactDate { get; set; }
    }
}
