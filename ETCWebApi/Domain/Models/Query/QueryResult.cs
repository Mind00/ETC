using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETCWebApi.Domain.Models.Query
{
    public class QueryResult<T>
    {
        public List<T> Items { get; set; } = new List<T>();
        public int TotalItems { get; set; } = 0;
    }
}
