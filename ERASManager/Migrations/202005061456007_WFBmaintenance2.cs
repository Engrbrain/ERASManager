namespace ERASManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WFBmaintenance2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GasAccountingREVMappings", "ReportField", c => c.String(maxLength: 500));
            AlterColumn("dbo.InstrumentElectricals", "Report", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.InstrumentElectricals", "Report", c => c.String());
            AlterColumn("dbo.GasAccountingREVMappings", "ReportField", c => c.String(maxLength: 50));
        }
    }
}
