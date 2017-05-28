using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Entities
{
    [Table("Cuentas")]
    public partial class Cuenta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cuenta()
        {
            CodigoCuenta k = new CodigoCuenta();
        }

        public int Id { get; set; }

        public int IdUsuario { get; set; }

        [StringLength(50)]
        public string NombreUsuario { get; set; }

        [StringLength(50)]
        public string Contrasena { get; set; }

        public int? Tipo { get; set; }

        public int? Estado { get; set; }

        public DateTime? FechaRegistro { get; set; }

        public DateTime? FechaVencimiento { get; set; }

        [StringLength(100)]
        public string TokenActivacion { get; set; }

        public DateTime? TokenVencimiento { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<CodigoCuenta> CodigoCuenta { get; set; }

        //public virtual EstadoCuenta EstadoCuenta { get; set; }

        //public virtual Usuario Usuario { get; set; }

        //public virtual TipoCuenta TipoCuenta { get; set; }

        

    }
}
