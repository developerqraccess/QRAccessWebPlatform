using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Entities
{
    [Table("Codigos")]
    public partial class Codigo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Codigo()
        {
            CodigosCuenta = new HashSet<CodigoCuenta>();
        }

        public int Id { get; set; }

        public int? Identificador { get; set; }

        [MaxLength(200)]
        public byte[] TOKEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CodigoCuenta> CodigosCuenta { get; set; }
    }
}
