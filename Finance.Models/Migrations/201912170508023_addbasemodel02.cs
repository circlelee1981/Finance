namespace Finance.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addbasemodel02 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Position", c => c.Int(nullable: false));
            AddColumn("dbo.CostRequirementInvoiceReceiveds", "CreateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.CostRequirementInvoiceReceiveds", "IsRemoved", c => c.Boolean(nullable: false));
            AddColumn("dbo.CostRequirementInvoiceReceiveds", "UserID", c => c.Int(nullable: false));
            AddColumn("dbo.CostRequirementInvoiceReceiveds", "Note", c => c.String(maxLength: 180));
            CreateIndex("dbo.CostRequirementInvoiceReceiveds", "UserID");
            AddForeignKey("dbo.CostRequirementInvoiceReceiveds", "UserID", "dbo.Users", "ID");
            DropColumn("dbo.CostRequirementInvoiceReceiveds", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CostRequirementInvoiceReceiveds", "Description", c => c.String());
            DropForeignKey("dbo.CostRequirementInvoiceReceiveds", "UserID", "dbo.Users");
            DropIndex("dbo.CostRequirementInvoiceReceiveds", new[] { "UserID" });
            DropColumn("dbo.CostRequirementInvoiceReceiveds", "Note");
            DropColumn("dbo.CostRequirementInvoiceReceiveds", "UserID");
            DropColumn("dbo.CostRequirementInvoiceReceiveds", "IsRemoved");
            DropColumn("dbo.CostRequirementInvoiceReceiveds", "CreateTime");
            DropColumn("dbo.Users", "Position");
        }
    }
}
