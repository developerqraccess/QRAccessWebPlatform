namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201705161 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cuentas", "TokenActivacion", c => c.String(maxLength: 100));
            AddColumn("dbo.Cuentas", "TokenVencimiento", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cuentas", "TokenVencimiento");
            DropColumn("dbo.Cuentas", "TokenActivacion");
        }
    }
}
