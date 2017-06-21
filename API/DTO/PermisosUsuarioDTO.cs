using DATA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.DTO
{
    public class PermisosUsuarioDTO : PermisosXUsuario
    {
        public string NombreUsuario { get; set; }

        public string NombrePermiso { get; set; }

        public string URl { get; set; }
    }
}