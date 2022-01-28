namespace ERASManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lateststructureupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RBackAllocationMasters", "WellTestEnrichmentData_Id", c => c.Int());
            CreateIndex("dbo.RBackAllocationMasters", "WellTestEnrichmentData_Id");
            AddForeignKey("dbo.RBackAllocationMasters", "WellTestEnrichmentData_Id", "dbo.WellTestEnrichmentDatas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RBackAllocationMasters", "WellTestEnrichmentData_Id", "dbo.WellTestEnrichmentDatas");
            DropIndex("dbo.RBackAllocationMasters", new[] { "WellTestEnrichmentData_Id" });
            DropColumn("dbo.RBackAllocationMasters", "WellTestEnrichmentData_Id");
        }
    }
}
