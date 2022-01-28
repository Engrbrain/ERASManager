namespace ERASManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DailySafetyTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DailySafetySummaries", "SafetyReport", c => c.String(maxLength: 500));
            AlterColumn("dbo.DailySafetySummaries", "UploadTime", c => c.String(maxLength: 150));
            AlterColumn("dbo.DailySafetySummaries", "DayOftheWeek", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DailySafetySummaries", "DayOftheWeek", c => c.String());
            AlterColumn("dbo.DailySafetySummaries", "UploadTime", c => c.String());
            AlterColumn("dbo.DailySafetySummaries", "SafetyReport", c => c.String());
        }
    }
}
