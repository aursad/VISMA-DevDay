using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DevDay.Model;
using DevDay.Repository.Common;

namespace DevDay.Repository
{
    public class MessageRepository : GenericRepository<MessageEntity>, IMessageRepository
    {
        public MessageRepository(DbContext context)
            : base(context)
        {

        }

        public IEnumerable<MessageEntity> GetMessages(Guid retroId)
        {
            return _entities.Set<MessageEntity>().AsEnumerable().Where(q => q.RetroGuid == retroId);
        }

    }
}