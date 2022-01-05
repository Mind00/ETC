using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETCWebApi.Resources
{
    public class NoticeResource
    {
        public int nId { get; set; }
        public DateTime issuedDate { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime postedOn { get; set; }
        public int postedBy { get; set; }
    }
}
