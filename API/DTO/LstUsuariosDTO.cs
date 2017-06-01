using DATA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.DTO
{
    public class LstUsuariosDTO : Usuario
    {
        public string TipoCuenta { get; set; }

        public int? Estado { get; set; }
    }
}