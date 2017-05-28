using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
     [RoutePrefix("api/TypeAccount")]
    public class TypeAccountController : ApiController
    {
        AuthRepository _repo = null;
        SignUpModel _mdl = null;

        public TypeAccountController()
        {
            _repo = new AuthRepository();
            _mdl = new SignUpModel();
        }

        [Authorize]
        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get()
        {
            return Ok(_mdl.GetTypeAccount());
        }



    }
}
