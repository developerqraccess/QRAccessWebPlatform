namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCampoIpDevice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bitacoras", "IpDispositivo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bitacoras", "IpDispositivo");
        }
    }
}
