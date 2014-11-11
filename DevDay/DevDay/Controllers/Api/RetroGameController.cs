using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DevDay.Model;
using DevDay.Service.Retro;
using DevDay.ViewModel;

namespace DevDay.Controllers.Api
{
    public class RetroGameController : ApiController
    {
        readonly IRetroService _retroService;
        private readonly IPersonService _personService;

        public RetroGameController(IRetroService retroService, IPersonService personService)
        {
            _retroService = retroService;
            _personService = personService;
        }

        public IHttpActionResult Get()
        {
            var retro = _retroService.FindAll();
            return Ok(retro);
        }

        public IHttpActionResult Post()
        {
            var person = new PersonEntity
            {
                IdPerson = Guid.NewGuid(),
                Name = "Aurimas"
            };
            var retroEntity = new RetroEntity
            {
                IdRetro = Guid.NewGuid(),
                Person = person,
                IdPerson = person.IdPerson
            };
            person.IdRetro = retroEntity.IdRetro;
            person.Retro = retroEntity;

            _retroService.Create(retroEntity);
            return Ok();
        }
    }
}
