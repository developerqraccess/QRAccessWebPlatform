namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBitacora : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bitacoras",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Token = c.String(),
                        FechayHoraIngreso = c.DateTime(nullable: false),
                        FechayHoraSalida = c.DateTime(),
                        UserName = c.String(),
                        NombrePc = c.String(),
                        TipoInicio = c.Int(nullable: false),
                        Usuario_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_Id)
                .Index(t => t.Usuario_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bitacoras", "Usuario_Id", "dbo.Usuarios");
            DropIndex("dbo.Bitacoras", new[] { "Usuario_Id" });
            DropTable("dbo.Bitacoras");
        }
    }
}
