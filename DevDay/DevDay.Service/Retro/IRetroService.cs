using System.Collections.Generic;
using DevDay.Model;

namespace DevDay.Service.Retro
{
    public interface IRetroService : IEntityService<RetroEntity>
    {
        RetroEntity GetById(int id);
        IEnumerable<RetroEntity> FindAll();
    }
}