using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Entities
{
    public class Permisos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Pantalla { get; set; }

        [Required]
        [MaxLength(500)]
        public string UrlPantalla { get; set; }

        public bool Activo { get; set; }

        public ICollection<PermisosXUsuario> PermisosXUsuarios { get; set; }
    }
}
