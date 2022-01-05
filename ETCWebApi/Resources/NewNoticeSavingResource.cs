using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETCWebApi.Resources
{
    public class NewNoticeSavingResource
    {
        [Required]
        public DateTime issuedDate { get; set; }
        [Required]
        public string title { get; set; }

        [Required]
        public string description { get; set; }
        [Required]
        public DateTime postedOn { get; set; }
        [Required]
        public int postedBy { get; set; }
    }
}
