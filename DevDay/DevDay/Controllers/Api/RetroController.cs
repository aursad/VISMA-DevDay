using System;
using System.Web.Http;
using DevDay.Model;
using DevDay.Service.Retro;
using DevDay.ViewModel;

namespace DevDay.Controllers.Api
{
    public class RetroController : ApiController
    {
        readonly IRetroService _retroService;

        public RetroController(IRetroService retroService)
        {
            _retroService = retroService;
        }

        // GET: api/Retro
        public IHttpActionResult Get()
        {
            var retro = _retroService.FindAll();

            return Ok(retro);
        }

        // GET: api/Retro/5
        public IHttpActionResult Get(Guid id)
        {
            var retro = _retroService.GetById(id);

            return Ok(retro);
        }

        // POST: api/Retro
        public IHttpActionResult Post([FromBody]RetroViewModel retroViewModel)
        {
            var retro = new RetroEntity
            {
                CreateTime = DateTime.Now,
                RetroType = RetroTypeEnum.WriteMode,
                Person = new PersonEntity
                {
                    Name = retroViewModel.Name,
                    PersonGuid = Guid.NewGuid()
                },
                Name = Guid.Parse("5038cfbd-45a6-46b3-90d6-05358b172b81")
            };
            retro.Person.RetroGuid = retro.Name;

            _retroService.Create(retro);

            return Ok(new { Id = retro.Name });
        }

        // PUT: api/Retro/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Retro/5
        public void Delete(int id)
        {
        }
    }
}
