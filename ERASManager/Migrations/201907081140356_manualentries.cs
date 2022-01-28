namespace ERASManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class manualentries : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ManualEntries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Well = c.String(maxLength: 150),
                        IndicatorDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        BLPD = c.Double(nullable: false),
                        AssumedGOR = c.Double(nullable: false),
                        WaterOverboard = c.Double(nullable: false),
                        Pumpablecargo = c.Double(nullable: false),
                        FreeWaterReceived = c.Double(nullable: false),
                        UllageMeasurement = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ManualEntries");
        }
    }
}
