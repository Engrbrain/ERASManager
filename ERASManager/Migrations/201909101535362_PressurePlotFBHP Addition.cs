namespace ERASManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PressurePlotFBHPAddition : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PressurePlotFBHPs", "DischargePressure", c => c.Double(nullable: false));
            AddColumn("dbo.PressurePlotFBHPs", "MotorTemperature", c => c.Double(nullable: false));
            AddColumn("dbo.PressurePlotFBHPs", "Frequency", c => c.Double(nullable: false));
            AddColumn("dbo.PressurePlotFBHPs", "AvgVSDCurrent", c => c.Double(nullable: false));
            AddColumn("dbo.PressurePlotFBHPs", "DriveVolts", c => c.Double(nullable: false));
            AddColumn("dbo.PressurePlotFBHPs", "SysCurrent", c => c.Double(nullable: false));
            AddColumn("dbo.PressurePlotFBHPs", "XVibration", c => c.Double(nullable: false));
            AddColumn("dbo.PressurePlotFBHPs", "YVibration", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PressurePlotFBHPs", "YVibration");
            DropColumn("dbo.PressurePlotFBHPs", "XVibration");
            DropColumn("dbo.PressurePlotFBHPs", "SysCurrent");
            DropColumn("dbo.PressurePlotFBHPs", "DriveVolts");
            DropColumn("dbo.PressurePlotFBHPs", "AvgVSDCurrent");
            DropColumn("dbo.PressurePlotFBHPs", "Frequency");
            DropColumn("dbo.PressurePlotFBHPs", "MotorTemperature");
            DropColumn("dbo.PressurePlotFBHPs", "DischargePressure");
        }
    }
}
