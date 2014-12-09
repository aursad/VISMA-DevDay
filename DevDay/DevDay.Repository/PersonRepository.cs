using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DevDay.Model;
using DevDay.Repository.Common;

namespace DevDay.Repository
{
    public class PersonRepository : GenericRepository<PersonEntity>, IPersonRepository
    {
        public PersonRepository(DbContext context)
            : base(context)
        {

        }

        public IEnumerable<PersonEntity> Get()
        {
            return _entities.Set<PersonEntity>().AsEnumerable();
        }

        public PersonEntity GetSingle(int retroId)
        {
            return _dbset.FirstOrDefault(x => x.Id == retroId);
        }

        public IEnumerable<PersonEntity> GetAllByRetro(Guid retroId)
        {
            return _entities.Set<PersonEntity>().AsEnumerable().Where(q => q.RetroGuid == retroId);
        }
    }
}