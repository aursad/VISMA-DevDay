using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevDay.Models;

namespace DevDay.Repository
{
    public interface IRetroRepository : IRepository<RetroModel, Guid>
    {
        IEnumerable<RetroModel> FindAll();
        IEnumerable<RetroModel> Find(int retroId);
    }
}