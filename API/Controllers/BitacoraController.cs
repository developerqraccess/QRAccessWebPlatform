using API.Models;
using DATA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/Bitacora")]
    public class BitacoraController : ApiController
    {

        AuthRepository _repo = null;
        BitacoraModel _mdl = null;


        public BitacoraController() {
            _repo = new AuthRepository();
            _mdl = new BitacoraModel();
        }


        [Authorize]
        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get()
        {
            try
            {
                object result = _mdl.GetBitacora();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }           
        }


        [Authorize]
        [HttpPost]
        [Route("Post")]
        public IHttpActionResult Post(Bitacora bitacora)
        {
            try
            {
                _mdl.SetBitacora(bitacora);
                return Ok();
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.ToString());
            }
        
        
        }




        [Authorize]
        [HttpPost]
        [Route("Put")]
        public IHttpActionResult Put(string Usuario) {
            try
            {
                _mdl.PutBitacora(Usuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        
        
        }


    }
}
