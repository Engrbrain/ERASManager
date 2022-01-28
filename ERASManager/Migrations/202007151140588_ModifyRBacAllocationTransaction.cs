namespace ERASManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyRBacAllocationTransaction : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RBK_TransactionalData", "GasPotential", c => c.Double(nullable: false));
            AddColumn("dbo.RBK_TransactionalData", "WellAllocatedWaterProd", c => c.Double(nullable: false));
            AddColumn("dbo.RBK_TransactionalData", "WellAllocatedGasProd", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RBK_TransactionalData", "WellAllocatedGasProd");
            DropColumn("dbo.RBK_TransactionalData", "WellAllocatedWaterProd");
            DropColumn("dbo.RBK_TransactionalData", "GasPotential");
        }
    }
}
