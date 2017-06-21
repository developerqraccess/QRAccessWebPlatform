using API.DTO;
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
    [RoutePrefix("api/Permisions")]
    public class PermisionsController : ApiController
    {
        AuthRepository _repo = null;
        PermisionsModel _mdl = null;

        public PermisionsController()
        {
            _repo = new AuthRepository();
            _mdl = new PermisionsModel();
        }


        [Authorize]
        [HttpPost]
        [Route("GetPermisionsUser")]
        public IHttpActionResult Get(Usuario user)
        {
            try
            {
                object result = _mdl.GetPermisionsForUsers(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }         
        }


        [Authorize]
        [HttpPost]
        [Route("Put")]
        public IHttpActionResult Put(PermisosUsuarioDTO permision)
        {
            try
            {
                return Ok(_mdl.PutPermisionsForUser(permision));
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }
        }


    }
}
