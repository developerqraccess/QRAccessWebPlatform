using DATA.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Entities
{
    public class Bitacora
    {

        [Key]
        public Int64 Id { get; set; }
        public string Token { get; set; }

        public DateTime FechayHoraIngreso { get; set; }

        public DateTime? FechayHoraSalida { get; set; }

        public string UserName { get; set; }

        public string NombrePc { get; set; }

        public TipoInicio TipoInicio { get; set; }

        public string IpDispositivo { get; set; }


    }
}
