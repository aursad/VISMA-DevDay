using System;
using System.Collections.Generic;
using DevDay.Model;

namespace DevDay.Service.Retro
{
    public interface IRetroService : IEntityService<RetroEntity>
    {
        RetroEntity GetById(Guid id);
        IEnumerable<RetroEntity> FindAll();
    }
}