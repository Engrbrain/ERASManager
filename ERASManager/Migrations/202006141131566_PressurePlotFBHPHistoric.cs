namespace ERASManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PressurePlotFBHPHistoric : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PressurePlotFBHPHistorics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IndicatorDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Well = c.String(maxLength: 150),
                        Pressure = c.Double(nullable: false),
                        Temperature = c.Double(nullable: false),
                        DischargePressure = c.Double(nullable: false),
                        MotorTemperature = c.Double(nullable: false),
                        Frequency = c.Double(nullable: false),
                        AvgVSDCurrent = c.Double(nullable: false),
                        DriveVolts = c.Double(nullable: false),
                        SysCurrent = c.Double(nullable: false),
                        XVibration = c.Double(nullable: false),
                        YVibration = c.Double(nullable: false),
                        ReportDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UploadTime = c.String(),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DayOftheWeek = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PressurePlotFBHPHistorics");
        }
    }
}
