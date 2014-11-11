using System.Collections.Generic;
using DevDay.Model;

namespace DevDay.Service.Retro
{
    public interface IPersonService : IEntityService<PersonEntity>
    {
        PersonEntity GetSingle(int id);
        IEnumerable<PersonEntity> FindAll();
    }
}