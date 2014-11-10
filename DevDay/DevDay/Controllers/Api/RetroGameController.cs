﻿using System.Web.Http;
using DevDay.Repository;

namespace DevDay.Controllers.Api
{
    public class RetroGameController : ApiController
    {
        private readonly IRetroRepository _retroRepository;

        public RetroGameController()
        {
            _retroRepository = new RetroRepository();
        }

        public RetroGameController(IRetroRepository retroRepository)
        {
            _retroRepository = retroRepository;
        }

        public IHttpActionResult Get()
        {
            var retro = _retroRepository.FindAll();
            return Ok(retro);
        }
    }
}
