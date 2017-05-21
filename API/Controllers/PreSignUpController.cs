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
        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get()
        {
            return Ok(_mdl.GetSignUpModel());
        }

        [Authorize]
        [HttpPost]
        [Route("Set")]
        public IHttpActionResult Set(Usuario user)
        {

            try {
                object result = _mdl.SetSignUpModel(user);
                return Ok(result);
            }
            catch (Exception ex) {
                return BadRequest(ex.ToString());
            }
            
             
        }

        [Authorize]
        [HttpPost]
        [Route("Put")]
        public IHttpActionResult Put(Usuario user)
        {
            try {
                return Ok(_mdl.PutSignUpModel(user));
            }
            catch (DbUpdateConcurrencyException) {
                return BadRequest();
            }  
        }

        [Authorize]
        [HttpPost]
        [Route("Delete")]
        public IHttpActionResult Delete(Usuario user)
        {
            IHttpActionResult result;

            try
            {
                _mdl.DeleteSignUpModel(user);
            }
            catch (Exception)
            {
                result = BadRequest();
            }
            finally
            {
                result = Ok();
            }

            return result;
        }
    }
}
