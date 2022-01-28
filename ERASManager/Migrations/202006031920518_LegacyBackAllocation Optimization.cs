namespace ERASManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LegacyBackAllocationOptimization : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BackAllocationQlestSummaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IndicatorDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CFBLiquidPotential = c.Double(nullable: false),
                        WFBLiquidPotential = c.Double(nullable: false),
                        TQlest = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.BackAllocationQoestHeaders", "WFBOilPotential", c => c.Double(nullable: false));
            AddColumn("dbo.BackAllocationQoestHeaders", "CFBOilPotential", c => c.Double(nullable: false));
            AddColumn("dbo.BackAllocationQoestHeaders", "CFBPlatformPotential", c => c.Double(nullable: false));
            AddColumn("dbo.BackAllocationQoestHeaders", "WFBPlatformPotential", c => c.Double(nullable: false));
            AddColumn("dbo.BackAllocationQoestHeaders", "CFBAllocatedProduction", c => c.Double(nullable: false));
            AddColumn("dbo.BackAllocationQoestHeaders", "WFBAllocatedProduction", c => c.Double(nullable: false));
            AddColumn("dbo.BackAllocationQoestHeaders", "CalWFBSF", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BackAllocationQoestHeaders", "CalWFBSF");
            DropColumn("dbo.BackAllocationQoestHeaders", "WFBAllocatedProduction");
            DropColumn("dbo.BackAllocationQoestHeaders", "CFBAllocatedProduction");
            DropColumn("dbo.BackAllocationQoestHeaders", "WFBPlatformPotential");
            DropColumn("dbo.BackAllocationQoestHeaders", "CFBPlatformPotential");
            DropColumn("dbo.BackAllocationQoestHeaders", "CFBOilPotential");
            DropColumn("dbo.BackAllocationQoestHeaders", "WFBOilPotential");
            DropTable("dbo.BackAllocationQlestSummaries");
        }
    }
}
