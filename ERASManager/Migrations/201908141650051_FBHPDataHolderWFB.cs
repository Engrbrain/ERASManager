namespace ERASManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FBHPDataHolderWFB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FBHPDataHolderWFBs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IndicatorDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        F1 = c.String(maxLength: 150),
                        F2 = c.String(maxLength: 150),
                        F3 = c.String(maxLength: 150),
                        F4 = c.String(maxLength: 150),
                        F5 = c.String(maxLength: 150),
                        F6 = c.String(maxLength: 150),
                        F7 = c.String(maxLength: 150),
                        F8 = c.String(maxLength: 150),
                        F9 = c.String(maxLength: 150),
                        F10 = c.String(maxLength: 150),
                        F11 = c.String(maxLength: 150),
                        F12 = c.String(maxLength: 150),
                        F13 = c.String(maxLength: 150),
                        F14 = c.String(maxLength: 150),
                        F15 = c.String(maxLength: 150),
                        F16 = c.String(maxLength: 150),
                        F17 = c.String(maxLength: 150),
                        F18 = c.String(maxLength: 150),
                        F19 = c.String(maxLength: 150),
                        F20 = c.String(maxLength: 150),
                        F21 = c.String(maxLength: 150),
                        F22 = c.String(maxLength: 150),
                        F23 = c.String(maxLength: 150),
                        F24 = c.String(maxLength: 150),
                        F25 = c.String(maxLength: 150),
                        F26 = c.String(maxLength: 150),
                        F27 = c.String(maxLength: 150),
                        F28 = c.String(maxLength: 150),
                        F29 = c.String(maxLength: 150),
                        F30 = c.String(maxLength: 150),
                        F31 = c.String(maxLength: 150),
                        F32 = c.String(maxLength: 150),
                        F33 = c.String(maxLength: 150),
                        F34 = c.String(maxLength: 150),
                        F35 = c.String(maxLength: 150),
                        F36 = c.String(maxLength: 150),
                        F37 = c.String(maxLength: 150),
                        F38 = c.String(maxLength: 150),
                        F39 = c.String(maxLength: 150),
                        F40 = c.String(maxLength: 150),
                        F41 = c.String(maxLength: 150),
                        F42 = c.String(maxLength: 150),
                        F43 = c.String(maxLength: 150),
                        F44 = c.String(maxLength: 150),
                        F45 = c.String(maxLength: 150),
                        F46 = c.String(maxLength: 150),
                        F47 = c.String(maxLength: 150),
                        F48 = c.String(maxLength: 150),
                        F49 = c.String(maxLength: 150),
                        F50 = c.String(maxLength: 150),
                        F51 = c.String(maxLength: 150),
                        F52 = c.String(maxLength: 150),
                        F53 = c.String(maxLength: 150),
                        F54 = c.String(maxLength: 150),
                        F55 = c.String(maxLength: 150),
                        F56 = c.String(maxLength: 150),
                        F57 = c.String(maxLength: 150),
                        F58 = c.String(maxLength: 150),
                        F59 = c.String(maxLength: 150),
                        F60 = c.String(maxLength: 150),
                        F61 = c.String(maxLength: 150),
                        F62 = c.String(maxLength: 150),
                        F63 = c.String(maxLength: 150),
                        F64 = c.String(maxLength: 150),
                        F65 = c.String(maxLength: 150),
                        F66 = c.String(maxLength: 150),
                        F67 = c.String(maxLength: 150),
                        F68 = c.String(maxLength: 150),
                        F69 = c.String(maxLength: 150),
                        F70 = c.String(maxLength: 150),
                        ReportDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UploadTime = c.String(),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DayOftheWeek = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FBHPDataHolderWFBs");
        }
    }
}
