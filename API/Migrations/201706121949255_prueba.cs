namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prueba : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PermisosXUsuarios",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Visualizar = c.Boolean(nullable: false),
                        Crear = c.Boolean(nullable: false),
                        Editar = c.Boolean(nullable: false),
                        Eliminar = c.Boolean(nullable: false),
                        Permisos_ID = c.Int(),
                        Usuarios_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Permisos", t => t.Permisos_ID)
                .ForeignKey("dbo.Usuarios", t => t.Usuarios_Id)
                .Index(t => t.Permisos_ID)
                .Index(t => t.Usuarios_Id);
            
            CreateTable(
                "dbo.Permisos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Pantalla = c.String(nullable: false, maxLength: 50),
                        UrlPantalla = c.String(nullable: false, maxLength: 500),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PermisosXUsuarios", "Usuarios_Id", "dbo.Usuarios");
            DropForeignKey("dbo.PermisosXUsuarios", "Permisos_ID", "dbo.Permisos");
            DropIndex("dbo.PermisosXUsuarios", new[] { "Usuarios_Id" });
            DropIndex("dbo.PermisosXUsuarios", new[] { "Permisos_ID" });
            DropTable("dbo.Permisos");
            DropTable("dbo.PermisosXUsuarios");
        }
    }
}
