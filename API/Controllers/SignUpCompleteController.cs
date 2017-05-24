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
    [RoutePrefix("api/SignUpComplete")]
    public class SignUpCompleteController : ApiController
    {
        AuthRepository _repo = null;
        SignUpModel _mdl = null;

        public SignUpCompleteController()
        {
            _repo = new AuthRepository();
            _mdl = new SignUpModel();
        }

        [Route("GetUserInfo/{tkn}")]
        public IHttpActionResult Get(string tkn)
        {
            if (_mdl.ValidateAccountToken(tkn))
                return Ok(_mdl.GetUserInformation(tkn));
            else 
                return BadRequest();

}

        [Route("SetUserInfo")]
        public IHttpActionResult SetUser(Usuario usr) {
            _mdl.SetUserInformation(usr);
            return Ok();
        }

        [Route("SetAccountInfo")]
        public IHttpActionResult SetAccount(Cuenta cnt) {
            _mdl.SetAccountInformation(cnt);
            return Ok();
        }
    }
}
