using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Entities
{
    [Table("CodigosCuenta")]
    public partial class CodigoCuenta
    {
        public int Id { get; set; }

        public int IdCuenta { get; set; }

        public int IdCodigo { get; set; }

        public int? Estado { get; set; }

        public DateTime? FechaRegistro { get; set; }

        public bool? Activo { get; set; }

        public virtual Codigo Codigo { get; set; }

        public virtual EstadoCodigoCuenta EstadoCodigoCuenta { get; set; }

        public virtual Cuenta Cuentas { get; set; }
    }
}
