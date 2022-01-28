namespace ERASManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CFBmaintenance : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CFBMaintenanceDatas", "Cummulative", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CFBMaintenanceDatas", "Cummulative", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
    }
}
