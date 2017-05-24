namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201705231 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cuentas", "Contrasena", c => c.String(maxLength: 50));
            DropColumn("dbo.Cuentas", "Contraseña");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cuentas", "Contraseña", c => c.String(maxLength: 50));
            DropColumn("dbo.Cuentas", "Contrasena");
        }
    }
}
