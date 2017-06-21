using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Entities
{
    public class PermisosXUsuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }


        public bool Visualizar { get; set; }
        public bool Crear { get; set; }

        public bool Editar { get; set; }

        public bool Eliminar { get; set; }

        public virtual Permisos Permisos {get; set;}

        public virtual Usuario Usuarios {get;set;}
    }
}

