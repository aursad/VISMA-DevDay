using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevDay.Model;
using DevDay.Repository.Common;

namespace DevDay.Repository
{
    public interface IRetroRepository : IGenericRepository<RetroEntity>
    {
        IEnumerable<RetroEntity> FindAll();
        RetroEntity Find(Guid retroId);
    }
}