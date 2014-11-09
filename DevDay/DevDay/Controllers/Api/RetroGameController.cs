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
            return Ok(new[] {"test", "test2"});
        }
    }
}
