namespace ERASManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReserviorEngineeringdataset : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FBHPDataHolderCFBs",
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
            
            CreateTable(
                "dbo.FBHPDataHolderESPs",
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
                        ReportDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UploadTime = c.String(),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DayOftheWeek = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReserviorWellsDailyDatas",
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
                        F71 = c.String(maxLength: 150),
                        F72 = c.String(maxLength: 150),
                        F73 = c.String(maxLength: 150),
                        F74 = c.String(maxLength: 150),
                        F75 = c.String(maxLength: 150),
                        F76 = c.String(maxLength: 150),
                        F77 = c.String(maxLength: 150),
                        F78 = c.String(maxLength: 150),
                        F79 = c.String(maxLength: 150),
                        F80 = c.String(maxLength: 150),
                        F81 = c.String(maxLength: 150),
                        F82 = c.String(maxLength: 150),
                        F83 = c.String(maxLength: 150),
                        F84 = c.String(maxLength: 150),
                        F85 = c.String(maxLength: 150),
                        F86 = c.String(maxLength: 150),
                        F87 = c.String(maxLength: 150),
                        F88 = c.String(maxLength: 150),
                        F89 = c.String(maxLength: 150),
                        F90 = c.String(maxLength: 150),
                        F91 = c.String(maxLength: 150),
                        F92 = c.String(maxLength: 150),
                        F93 = c.String(maxLength: 150),
                        F94 = c.String(maxLength: 150),
                        F95 = c.String(maxLength: 150),
                        F96 = c.String(maxLength: 150),
                        F97 = c.String(maxLength: 150),
                        F98 = c.String(maxLength: 150),
                        F99 = c.String(maxLength: 150),
                        F100 = c.String(maxLength: 150),
                        F101 = c.String(maxLength: 150),
                        F102 = c.String(maxLength: 150),
                        F103 = c.String(maxLength: 150),
                        F104 = c.String(maxLength: 150),
                        F105 = c.String(maxLength: 150),
                        F106 = c.String(maxLength: 150),
                        F107 = c.String(maxLength: 150),
                        F108 = c.String(maxLength: 150),
                        F109 = c.String(maxLength: 150),
                        F110 = c.String(maxLength: 150),
                        F111 = c.String(maxLength: 150),
                        F112 = c.String(maxLength: 150),
                        F113 = c.String(maxLength: 150),
                        F114 = c.String(maxLength: 150),
                        F115 = c.String(maxLength: 150),
                        F116 = c.String(maxLength: 150),
                        F117 = c.String(maxLength: 150),
                        F118 = c.String(maxLength: 150),
                        F119 = c.String(maxLength: 150),
                        F120 = c.String(maxLength: 150),
                        F121 = c.String(maxLength: 150),
                        F122 = c.String(maxLength: 150),
                        F123 = c.String(maxLength: 150),
                        F124 = c.String(maxLength: 150),
                        F125 = c.String(maxLength: 150),
                        F126 = c.String(maxLength: 150),
                        F127 = c.String(maxLength: 150),
                        F128 = c.String(maxLength: 150),
                        F129 = c.String(maxLength: 150),
                        F130 = c.String(maxLength: 150),
                        F131 = c.String(maxLength: 150),
                        F132 = c.String(maxLength: 150),
                        F133 = c.String(maxLength: 150),
                        F134 = c.String(maxLength: 150),
                        F135 = c.String(maxLength: 150),
                        F136 = c.String(maxLength: 150),
                        F137 = c.String(maxLength: 150),
                        F138 = c.String(maxLength: 150),
                        F139 = c.String(maxLength: 150),
                        F140 = c.String(maxLength: 150),
                        F141 = c.String(maxLength: 150),
                        F142 = c.String(maxLength: 150),
                        F143 = c.String(maxLength: 150),
                        F144 = c.String(maxLength: 150),
                        F145 = c.String(maxLength: 150),
                        F146 = c.String(maxLength: 150),
                        F147 = c.String(maxLength: 150),
                        F148 = c.String(maxLength: 150),
                        F149 = c.String(maxLength: 150),
                        F150 = c.String(maxLength: 150),
                        F151 = c.String(maxLength: 150),
                        F152 = c.String(maxLength: 150),
                        F153 = c.String(maxLength: 150),
                        F154 = c.String(maxLength: 150),
                        F155 = c.String(maxLength: 150),
                        F156 = c.String(maxLength: 150),
                        F157 = c.String(maxLength: 150),
                        F158 = c.String(maxLength: 150),
                        F159 = c.String(maxLength: 150),
                        F160 = c.String(maxLength: 150),
                        F161 = c.String(maxLength: 150),
                        F162 = c.String(maxLength: 150),
                        F163 = c.String(maxLength: 150),
                        F164 = c.String(maxLength: 150),
                        F165 = c.String(maxLength: 150),
                        F166 = c.String(maxLength: 150),
                        F167 = c.String(maxLength: 150),
                        F168 = c.String(maxLength: 150),
                        F169 = c.String(maxLength: 150),
                        F170 = c.String(maxLength: 150),
                        F171 = c.String(maxLength: 150),
                        F172 = c.String(maxLength: 150),
                        F173 = c.String(maxLength: 150),
                        F174 = c.String(maxLength: 150),
                        F175 = c.String(maxLength: 150),
                        F176 = c.String(maxLength: 150),
                        F177 = c.String(maxLength: 150),
                        F178 = c.String(maxLength: 150),
                        F179 = c.String(maxLength: 150),
                        F180 = c.String(maxLength: 150),
                        F181 = c.String(maxLength: 150),
                        F182 = c.String(maxLength: 150),
                        F183 = c.String(maxLength: 150),
                        F184 = c.String(maxLength: 150),
                        F185 = c.String(maxLength: 150),
                        F186 = c.String(maxLength: 150),
                        F187 = c.String(maxLength: 150),
                        F188 = c.String(maxLength: 150),
                        F189 = c.String(maxLength: 150),
                        F190 = c.String(maxLength: 150),
                        F191 = c.String(maxLength: 150),
                        F192 = c.String(maxLength: 150),
                        F193 = c.String(maxLength: 150),
                        F194 = c.String(maxLength: 150),
                        F195 = c.String(maxLength: 150),
                        F196 = c.String(maxLength: 150),
                        F197 = c.String(maxLength: 150),
                        F198 = c.String(maxLength: 150),
                        F199 = c.String(maxLength: 150),
                        F200 = c.String(maxLength: 150),
                        F201 = c.String(maxLength: 150),
                        F202 = c.String(maxLength: 150),
                        F203 = c.String(maxLength: 150),
                        F204 = c.String(maxLength: 150),
                        F205 = c.String(maxLength: 150),
                        F206 = c.String(maxLength: 150),
                        F207 = c.String(maxLength: 150),
                        F208 = c.String(maxLength: 150),
                        F209 = c.String(maxLength: 150),
                        F210 = c.String(maxLength: 150),
                        F211 = c.String(maxLength: 150),
                        F212 = c.String(maxLength: 150),
                        F213 = c.String(maxLength: 150),
                        F214 = c.String(maxLength: 150),
                        F215 = c.String(maxLength: 150),
                        F216 = c.String(maxLength: 150),
                        F217 = c.String(maxLength: 150),
                        F218 = c.String(maxLength: 150),
                        F219 = c.String(maxLength: 150),
                        F220 = c.String(maxLength: 150),
                        F221 = c.String(maxLength: 150),
                        ReportDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UploadTime = c.String(),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DayOftheWeek = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReserviorWellsDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IndicatorDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Well = c.String(maxLength: 150),
                        ChokeSize = c.Double(nullable: false),
                        FBHP = c.Double(nullable: false),
                        DP = c.Double(nullable: false),
                        FBHT = c.Double(nullable: false),
                        FTHP = c.Double(nullable: false),
                        FLP = c.Double(nullable: false),
                        InnerAnnulus = c.Double(nullable: false),
                        OuterAnnulus = c.Double(nullable: false),
                        FLT = c.Double(nullable: false),
                        ReportDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UploadTime = c.String(),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DayOftheWeek = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ReserviorWellsDatas");
            DropTable("dbo.ReserviorWellsDailyDatas");
            DropTable("dbo.FBHPDataHolderESPs");
            DropTable("dbo.FBHPDataHolderCFBs");
        }
    }
}
