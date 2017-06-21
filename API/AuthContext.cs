using DATA.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace API
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext()
            : base("AuthContext")
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Codigo> Codigos { get; set; }
        public DbSet<CodigoCuenta> CodigosCuenta { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<EstadoCodigoCuenta> EstadoCogidosCuenta { get; set; }
        public DbSet<EstadoCuenta> EstadosCuenta { get; set; }
        public DbSet<TipoCuenta> TipoCuentas { get; set; }

        public DbSet<Permisos> Permisos { get; set; }

        public DbSet<PermisosXUsuario> PermisosXUsuario { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }


        public DbSet<Bitacora> Bitacora { get; set; }

    }
}