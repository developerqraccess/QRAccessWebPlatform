using DATA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.DTO
{
    public class BitacoraDTO:Bitacora
    {
        public string TipoLogin { get; set; }
    }
}