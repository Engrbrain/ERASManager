namespace ERASManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createseperatorandexportlinedata : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReserviorWellExportLineDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IndicatorDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Well = c.String(maxLength: 150),
                        ChokeSize = c.Double(nullable: false),
                        WFBLiquidtoMOPU = c.Double(nullable: false),
                        WFBGastoMOPU = c.Double(nullable: false),
                        GasLiftHeaderPre = c.Double(nullable: false),
                        ReportDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UploadTime = c.String(),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DayOftheWeek = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReserviorWellSeperatorDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IndicatorDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Well = c.String(maxLength: 150),
                        WFBProdHeader = c.Double(nullable: false),
                        WFBProdSEPPress = c.Double(nullable: false),
                        WFBProdSEPTemp = c.Double(nullable: false),
                        WFBTestSEPInletPress = c.Double(nullable: false),
                        ReportDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UploadTime = c.String(),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DayOftheWeek = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ReserviorWellsDatas", "GasLiftChoke", c => c.Double(nullable: false));
            AddColumn("dbo.ReserviorWellsDatas", "GLMeter", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReserviorWellsDatas", "GLMeter");
            DropColumn("dbo.ReserviorWellsDatas", "GasLiftChoke");
            DropTable("dbo.ReserviorWellSeperatorDatas");
            DropTable("dbo.ReserviorWellExportLineDatas");
        }
    }
}
