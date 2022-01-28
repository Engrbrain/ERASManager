namespace ERASManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PressurePlotFBHP1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PressurePlotFBHPs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IndicatorDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Well = c.String(maxLength: 150),
                        Pressure = c.Double(nullable: false),
                        Temperature = c.Double(nullable: false),
                        ReportDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UploadTime = c.String(),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DayOftheWeek = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PressurePlotFBHPs");
        }
    }
}
