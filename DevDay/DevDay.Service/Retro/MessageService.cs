using System;
using System.Collections.Generic;
using DevDay.Model;
using DevDay.Repository;
using DevDay.Repository.Common;

namespace DevDay.Service.Retro
{
    public class MessageService : EntityService<MessageEntity>, IMessageService
  {
      IUnitOfWork _unitOfWork;
      IMessageRepository _messageRepository;

      public MessageService(IUnitOfWork unitOfWork, IMessageRepository retroRepository)
          : base(unitOfWork, retroRepository)
      {
          _unitOfWork = unitOfWork;
          _messageRepository = retroRepository;
      }

      public IEnumerable<MessageEntity> FindAll(Guid retroGuid)
      {
          return _messageRepository.GetMessages(retroGuid);
      }
  }
}