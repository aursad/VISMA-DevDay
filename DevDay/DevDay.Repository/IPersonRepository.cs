using System.Collections.Generic;
using DevDay.Model;
using DevDay.Repository.Common;

namespace DevDay.Repository
{
    public interface IPersonRepository : IGenericRepository<PersonEntity>
    {
        IEnumerable<PersonEntity> Get();
        PersonEntity GetSingle(int personId);
    }
}