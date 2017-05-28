namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCampoPermisosEnTipoCuenta : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TipoCuentas", "Permisos", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TipoCuentas", "Permisos");
        }
    }
}
