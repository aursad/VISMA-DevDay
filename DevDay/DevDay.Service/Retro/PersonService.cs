using System;
using System.Collections.Generic;
using DevDay.Model;
using DevDay.Repository;
using DevDay.Repository.Common;

namespace DevDay.Service.Retro
{
    public class PersonService : EntityService<PersonEntity>, IPersonService
  {
      IUnitOfWork _unitOfWork;
      IPersonRepository _personRepository;

      public PersonService(IUnitOfWork unitOfWork, IPersonRepository personRepository)
          : base(unitOfWork, personRepository)
      {
          _unitOfWork = unitOfWork;
          _personRepository = personRepository;
      }


      public PersonEntity GetSingle(int id)
      {
          return _personRepository.GetSingle(id);
      }

      public IEnumerable<PersonEntity> FindAll()
      {
          return _personRepository.GetAll();
      }
  }
}