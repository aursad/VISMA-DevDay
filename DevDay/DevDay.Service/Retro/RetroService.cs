using System;
using System.Collections.Generic;
using DevDay.Model;
using DevDay.Repository;
using DevDay.Repository.Common;

namespace DevDay.Service.Retro
{
    public class RetroService : EntityService<RetroEntity>, IRetroService
  {
      IUnitOfWork _unitOfWork;
      IRetroRepository _retroRepository;

      public RetroService(IUnitOfWork unitOfWork, IRetroRepository retroRepository)
          : base(unitOfWork, retroRepository)
      {
          _unitOfWork = unitOfWork;
          _retroRepository = retroRepository;
      }


      public RetroEntity GetById(Guid id)
      {
          return _retroRepository.Find(id);
      }

      public IEnumerable<RetroEntity> FindAll()
      {
          return _retroRepository.FindAll();
      }
  }
}