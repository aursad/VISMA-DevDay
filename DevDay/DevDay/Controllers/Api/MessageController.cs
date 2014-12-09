using System;
using System.Linq;
using System.Web.Http;
using DevDay.Model;
using DevDay.Service.Retro;
using DevDay.ViewModel;

namespace DevDay.Controllers.Api
{
    public class MessageController : ApiController
    {
        readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        // GET api/<controller>/5
        public IHttpActionResult Get()
        {
            return Ok();
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(Guid id)
        {
            var messages = _messageService.FindAll(id).ToList();

            var message = new MessageViewModel
            {
                Start = messages.Where(q => q.MessageType == MessageType.Start).ToList(),
                Stop = messages.Where(q => q.MessageType == MessageType.Stop).ToList(),
                Continue = messages.Where(q => q.MessageType == MessageType.Continious).ToList()
            };

            return Ok(message);
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