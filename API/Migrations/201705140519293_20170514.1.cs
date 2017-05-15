namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201705141 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Usuarios", "Correo", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Usuarios", "Correo", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
