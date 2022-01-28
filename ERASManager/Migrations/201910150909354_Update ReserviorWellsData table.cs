namespace ERASManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateReserviorWellsDatatable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReserviorWellsDatas", "Frequency", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReserviorWellsDatas", "Frequency");
        }
    }
}
