using API.Models;
using DATA.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/PreSignup")]
    public class PreSignUpController : ApiController
    {
        AuthRepository _repo = null;
        SignUpModel _mdl = null;

        public PreSignUpController()
        {
            _repo = new AuthRepository();
            _mdl = new SignUpModel();
        }

        [Authorize] 
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(_mdl.GetSignUpModel());  
        }

        [Authorize]
        [Route("")]
        public IHttpActionResult Set(Usuario user)
        {   
            return Ok(_mdl.SetSignUpModel(user)); 
        }

        [Authorize]
        [HttpPut]
        [Route("")]
        public IHttpActionResult Put(Usuario user)
        {
            try {
                return Ok(_mdl.PutSignUpModel(user));
            }
            catch (DbUpdateConcurrencyException) {
                return BadRequest();
            }  
        }

        //[Authorize]
        //[HttpDelete]
        //[Route("")]
        //public HttpResponseMessage Delete(int id)
        //{
        //    return new HttpResponseMessage(HttpStatusCode.OK);
        //}
        [Authorize]
        [AcceptVerbs("DELETE")]
        [Route("")]
        public HttpResponseMessage Delete(int id)
        {
            HttpStatusCode result = new HttpStatusCode();

            try {
                _mdl.DeleteSignUpModel(id);
            }
            catch (Exception) {
                result = HttpStatusCode.BadRequest;
            }
            finally {
                result = HttpStatusCode.OK;
            }

            return new HttpResponseMessage(result);
        }
    }
}
