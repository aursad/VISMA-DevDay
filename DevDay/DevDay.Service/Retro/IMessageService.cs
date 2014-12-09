using System;
using System.Collections.Generic;
using DevDay.Model;

namespace DevDay.Service.Retro
{
    public interface IMessageService : IEntityService<MessageEntity>
    {
        IEnumerable<MessageEntity> FindAll(Guid retroGuid);
    }
}