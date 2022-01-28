namespace ERASManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class include_GOR : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RBackAllocationMasters", "GOR", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RBackAllocationMasters", "GOR");
        }
    }
}
