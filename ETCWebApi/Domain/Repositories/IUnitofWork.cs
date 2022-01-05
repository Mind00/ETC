using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETCWebApi.Domain.Repositories
{
    public interface IUnitofWork
    {
        Task CompleteAsync();
    }
}
