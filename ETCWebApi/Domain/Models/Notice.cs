using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETCWebApi.Domain.models
{
    public class Notice
    {
        [Key]
        public int NId { get; set; }

        public DateTime IssuedDate { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
        public string PostedOn { get; set; }
        public string PostedBy { get; set; }
    }
}
