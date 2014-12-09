using System;
using System.Web.Http;
using DevDay.Service.Retro;

namespace DevDay.Controllers.Api
{
    public class PersonController : ApiController
    {
        readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        // GET api/<controller>/5
        public IHttpActionResult Get()
        {
            var persons = _personService.FindAll();

            return Ok(persons);
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(Guid id)
        {
            var persons = _personService.GetRetroPersons(id);

            return Ok(persons);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}