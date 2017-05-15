namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20170512MigracionInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Secret = c.String(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        ApplicationType = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        RefreshTokenLifeTime = c.Int(nullable: false),
                        AllowedOrigin = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Codigos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Identificador = c.Int(),
                        TOKEN = c.Binary(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CodigosCuenta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdCuenta = c.Int(nullable: false),
                        IdCodigo = c.Int(nullable: false),
                        Estado = c.Int(),
                        FechaRegistro = c.DateTime(),
                        Activo = c.Boolean(),
                        Codigo_Id = c.Int(),
                        Cuentas_Id = c.Int(),
                        EstadoCodigoCuenta_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Codigos", t => t.Codigo_Id)
                .ForeignKey("dbo.Cuentas", t => t.Cuentas_Id)
                .ForeignKey("dbo.EstadoCodigosCuenta", t => t.EstadoCodigoCuenta_Id)
                .Index(t => t.Codigo_Id)
                .Index(t => t.Cuentas_Id)
                .Index(t => t.EstadoCodigoCuenta_Id);
            
            CreateTable(
                "dbo.Cuentas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdUsuario = c.Int(nullable: false),
                        NombreUsuario = c.String(maxLength: 50),
                        Contraseña = c.String(maxLength: 50),
                        Tipo = c.Int(),
                        Estado = c.Int(),
                        FechaRegistro = c.DateTime(),
                        FechaVencimiento = c.DateTime(),
                        EstadoCuenta_Id = c.Int(),
                        TipoCuenta_Id = c.Int(),
                        Usuario_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EstadoCuentas", t => t.EstadoCuenta_Id)
                .ForeignKey("dbo.TipoCuentas", t => t.TipoCuenta_Id)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_Id)
                .Index(t => t.EstadoCuenta_Id)
                .Index(t => t.TipoCuenta_Id)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.EstadoCuentas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 50),
                        Orden = c.Int(nullable: false),
                        Activo = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipoCuentas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 50),
                        Orden = c.Int(nullable: false),
                        Activo = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cedula = c.String(nullable: false),
                        Nombre = c.String(maxLength: 50),
                        Apellidos = c.String(maxLength: 50),
                        FechaNacimiento = c.DateTime(),
                        Correo = c.String(nullable: false, maxLength: 50),
                        Direccion = c.String(maxLength: 100),
                        Movil = c.String(maxLength: 20),
                        Telefono = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EstadoCodigosCuenta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 50),
                        Orden = c.Int(nullable: false),
                        Activo = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RefreshTokens",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Subject = c.String(nullable: false, maxLength: 50),
                        ClientId = c.String(nullable: false, maxLength: 50),
                        IssuedUtc = c.DateTime(nullable: false),
                        ExpiresUtc = c.DateTime(nullable: false),
                        ProtectedTicket = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.CodigosCuenta", "EstadoCodigoCuenta_Id", "dbo.EstadoCodigosCuenta");
            DropForeignKey("dbo.Cuentas", "Usuario_Id", "dbo.Usuarios");
            DropForeignKey("dbo.Cuentas", "TipoCuenta_Id", "dbo.TipoCuentas");
            DropForeignKey("dbo.Cuentas", "EstadoCuenta_Id", "dbo.EstadoCuentas");
            DropForeignKey("dbo.CodigosCuenta", "Cuentas_Id", "dbo.Cuentas");
            DropForeignKey("dbo.CodigosCuenta", "Codigo_Id", "dbo.Codigos");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Cuentas", new[] { "Usuario_Id" });
            DropIndex("dbo.Cuentas", new[] { "TipoCuenta_Id" });
            DropIndex("dbo.Cuentas", new[] { "EstadoCuenta_Id" });
            DropIndex("dbo.CodigosCuenta", new[] { "EstadoCodigoCuenta_Id" });
            DropIndex("dbo.CodigosCuenta", new[] { "Cuentas_Id" });
            DropIndex("dbo.CodigosCuenta", new[] { "Codigo_Id" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.RefreshTokens");
            DropTable("dbo.EstadoCodigosCuenta");
            DropTable("dbo.Usuarios");
            DropTable("dbo.TipoCuentas");
            DropTable("dbo.EstadoCuentas");
            DropTable("dbo.Cuentas");
            DropTable("dbo.CodigosCuenta");
            DropTable("dbo.Codigos");
            DropTable("dbo.Clients");
        }
    }
}
