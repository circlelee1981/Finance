namespace Finance.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_CostRequirementInvoiceReceived_InvoiceReceived02 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CostRequirementInvoiceReceiveds",
                c => new
                    {
                        CostRequirementID = c.Int(nullable: false),
                        InvoiceReceivedID = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => new { t.CostRequirementID, t.InvoiceReceivedID })
                .ForeignKey("dbo.CostRequirements", t => t.CostRequirementID)
                .ForeignKey("dbo.InvoiceReceiveds", t => t.InvoiceReceivedID)
                .Index(t => t.CostRequirementID)
                .Index(t => t.InvoiceReceivedID);
            
            CreateTable(
                "dbo.InvoiceReceiveds",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        InvoiceSQNum = c.String(nullable: false, maxLength: 10),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                        UserID = c.Int(nullable: false),
                        Note = c.String(maxLength: 180),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.InvoiceSQNum, unique: true)
                .Index(t => t.UserID);
            
            AlterColumn("dbo.InvoiceRequirements", "Principal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CostRequirementInvoiceReceiveds", "InvoiceReceivedID", "dbo.InvoiceReceiveds");
            DropForeignKey("dbo.InvoiceReceiveds", "UserID", "dbo.Users");
            DropForeignKey("dbo.CostRequirementInvoiceReceiveds", "CostRequirementID", "dbo.CostRequirements");
            DropIndex("dbo.InvoiceReceiveds", new[] { "UserID" });
            DropIndex("dbo.InvoiceReceiveds", new[] { "InvoiceSQNum" });
            DropIndex("dbo.CostRequirementInvoiceReceiveds", new[] { "InvoiceReceivedID" });
            DropIndex("dbo.CostRequirementInvoiceReceiveds", new[] { "CostRequirementID" });
            AlterColumn("dbo.InvoiceRequirements", "Principal", c => c.Int(nullable: false));
            DropTable("dbo.InvoiceReceiveds");
            DropTable("dbo.CostRequirementInvoiceReceiveds");
        }
    }
}
