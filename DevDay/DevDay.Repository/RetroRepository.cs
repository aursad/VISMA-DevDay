using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DevDay.Model;
using DevDay.Repository.Common;

namespace DevDay.Repository
{
    public class RetroRepository : GenericRepository<RetroEntity>, IRetroRepository
    {
        public RetroRepository(DbContext context)
            : base(context)
        {

        }

        public IEnumerable<RetroEntity> FindAll()
        {
            return _entities.Set<RetroEntity>().AsEnumerable();
        }

        public RetroEntity Find(Guid retroId)
        {
            return _dbset.FirstOrDefault(x => x.Name == retroId);
        }
    }
}