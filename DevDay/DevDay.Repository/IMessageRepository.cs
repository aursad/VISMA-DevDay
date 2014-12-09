using System;
using System.Collections.Generic;
using DevDay.Model;
using DevDay.Repository.Common;

namespace DevDay.Repository
{
    public interface IMessageRepository : IGenericRepository<MessageEntity>
    {
        IEnumerable<MessageEntity> GetMessages(Guid retroId);
    }
}