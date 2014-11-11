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
                Name = "Aurimas"
            };
            var retro = new RetroEntity
            {
                CreateTime = DateTime.Now,
                RetroType = RetroTypeEnum.WriteMode,
                Person = person,
                Name = "Demo"
            };
            _retroService.Create(retro);
            return Ok();
        }
    }
}
