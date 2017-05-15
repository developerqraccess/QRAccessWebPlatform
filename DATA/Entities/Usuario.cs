using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Entities
{
    [Table("Usuarios")]
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            Cuenta = new HashSet<Cuenta>();
        }

        public int? Id { get; set; }

        [Required]
        public string Cedula { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(50)]
        public string Apellidos { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        [StringLength(50)]
        public string Correo { get; set; }

        [StringLength(100)]
        public string Direccion { get; set; }

        [StringLength(20)]
        public string Movil { get; set; }

        [StringLength(20)]
        public string Telefono { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cuenta> Cuenta { get; set; }
    }
}
