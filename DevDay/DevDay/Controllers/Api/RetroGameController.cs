using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DevDay.Controllers.Api
{
    public class RetroGameController : ApiController
    {
        public IHttpActionResult Get()
        {
            var online = new List<Member>
            {
                new Member
                {
                    Name = "Petras"
                },
                new Member
                {
                    Name = "Jonas"
                }
            };
            return Ok(online);
        }
    }

    class Member
    {
        public string Name { get; set; }
    }
}
