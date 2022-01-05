using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETCWebApi.Domain.Models.Query
{
    public class NoticeQuery: Query
    {

        public NoticeQuery(int page, int itemsPerPage) : base(page, itemsPerPage)
        {
            
        }
    }
}
