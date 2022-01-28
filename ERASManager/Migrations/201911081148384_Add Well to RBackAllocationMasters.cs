namespace ERASManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWelltoRBackAllocationMasters : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RBackAllocationMasters", "Well", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RBackAllocationMasters", "Well");
        }
    }
}
