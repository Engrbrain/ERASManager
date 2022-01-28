namespace ERASManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MappingandBackAllocationTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CFBPressurePlotFBHPMappings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastUpdateDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        NumberOfChanges = c.Int(nullable: false),
                        Well = c.String(maxLength: 50),
                        ReportField = c.String(maxLength: 50),
                        FieldDescription = c.String(maxLength: 50),
                        MappingFields = c.String(maxLength: 10),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EBOKFieldProductionMappings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastUpdateDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        NumberOfChanges = c.Int(nullable: false),
                        ReportField = c.String(maxLength: 50),
                        FieldDescription = c.String(maxLength: 50),
                        MappingFields = c.String(maxLength: 10),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EKOBDailyProductionMappings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastUpdateDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        NumberOfChanges = c.Int(nullable: false),
                        ReportField = c.String(maxLength: 50),
                        FieldDescription = c.String(maxLength: 50),
                        MappingFields = c.String(maxLength: 10),
                        StartRange = c.Int(nullable: false),
                        EndRange = c.Int(nullable: false),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ESPPressurePlotFBHPMappings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastUpdateDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        NumberOfChanges = c.Int(nullable: false),
                        Well = c.String(maxLength: 50),
                        ReportField = c.String(maxLength: 50),
                        FieldDescription = c.String(maxLength: 50),
                        MappingFields = c.String(maxLength: 10),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GasAccountingREVMappings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastUpdateDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        NumberOfChanges = c.Int(nullable: false),
                        ReportField = c.String(maxLength: 50),
                        FieldDescription = c.String(maxLength: 50),
                        MappingFields = c.String(maxLength: 10),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RBackAllocationMasters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IndicatorDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        BLPD = c.Double(nullable: false),
                        BSW = c.Double(nullable: false),
                        CFBStrinkageFactor = c.Double(nullable: false),
                        WFBStrinkageFactor = c.Double(nullable: false),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RBK_TransactionalData",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IndicatorDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Well = c.String(maxLength: 50),
                        LiquidPotential = c.Double(nullable: false),
                        OilPotential = c.Double(nullable: false),
                        CFBPlatformOilPotential = c.Double(nullable: false),
                        WFBPlatformOilPotential = c.Double(nullable: false),
                        CFBPlatformAllocatedProd = c.Double(nullable: false),
                        WFBPlatformAllocatedProd = c.Double(nullable: false),
                        WellAllocatedProd = c.Double(nullable: false),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WFBPressurePlotFBHPMappings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastUpdateDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        NumberOfChanges = c.Int(nullable: false),
                        Well = c.String(maxLength: 50),
                        ReportField = c.String(maxLength: 50),
                        FieldDescription = c.String(maxLength: 50),
                        MappingFields = c.String(maxLength: 10),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WFBPressurePlotFBHPMappings");
            DropTable("dbo.RBK_TransactionalData");
            DropTable("dbo.RBackAllocationMasters");
            DropTable("dbo.GasAccountingREVMappings");
            DropTable("dbo.ESPPressurePlotFBHPMappings");
            DropTable("dbo.EKOBDailyProductionMappings");
            DropTable("dbo.EBOKFieldProductionMappings");
            DropTable("dbo.CFBPressurePlotFBHPMappings");
        }
    }
}
