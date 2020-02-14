namespace Finance.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActualIncomes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BankSq = c.String(nullable: false, maxLength: 60),
                        Payer = c.String(nullable: false, maxLength: 60),
                        PayerBankName = c.String(nullable: false, maxLength: 60),
                        PayerBankAccount = c.String(nullable: false, maxLength: 30),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrencyType = c.Int(nullable: false),
                        OccurringDate = c.DateTime(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                        UserID = c.Int(nullable: false),
                        Note = c.String(maxLength: 180),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.BankSq, unique: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Receivables",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SalesWorkNo = c.String(nullable: false, maxLength: 60),
                        Merchant = c.String(nullable: false, maxLength: 60),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CollectionItem = c.String(nullable: false),
                        ActualIncomeID = c.Int(nullable: false),
                        Returnable = c.Boolean(nullable: false),
                        InvoiceRequirementID = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                        UserID = c.Int(nullable: false),
                        Note = c.String(maxLength: 180),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ActualIncomes", t => t.ActualIncomeID)
                .ForeignKey("dbo.InvoiceRequirements", t => t.InvoiceRequirementID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.ActualIncomeID)
                .Index(t => t.InvoiceRequirementID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.InvoiceRequirements",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 60),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxRate = c.Int(nullable: false),
                        IsSpecialTicket = c.Boolean(nullable: false),
                        Tax = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Principal = c.Int(nullable: false),
                        InvoiceIssuedID = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                        UserID = c.Int(nullable: false),
                        Note = c.String(maxLength: 180),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.InvoiceIssueds", t => t.InvoiceIssuedID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.InvoiceIssuedID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.InvoiceIssueds",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SQNum = c.String(maxLength: 10),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IssuedDate = c.DateTime(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                        UserID = c.Int(nullable: false),
                        Note = c.String(maxLength: 180),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.SQNum, unique: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Password = c.String(),
                        Team = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CostRequirements",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Receiver = c.String(nullable: false, maxLength: 60),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrencyType = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                        UserID = c.Int(nullable: false),
                        Note = c.String(maxLength: 180),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Payables",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SalesWorkNo = c.String(nullable: false, maxLength: 60),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrencyType = c.Int(nullable: false),
                        CollectionItem = c.String(nullable: false),
                        CostRequirementID = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                        UserID = c.Int(nullable: false),
                        Note = c.String(maxLength: 180),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CostRequirements", t => t.CostRequirementID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.CostRequirementID)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CostRequirements", "UserID", "dbo.Users");
            DropForeignKey("dbo.Payables", "UserID", "dbo.Users");
            DropForeignKey("dbo.Payables", "CostRequirementID", "dbo.CostRequirements");
            DropForeignKey("dbo.ActualIncomes", "UserID", "dbo.Users");
            DropForeignKey("dbo.Receivables", "UserID", "dbo.Users");
            DropForeignKey("dbo.Receivables", "InvoiceRequirementID", "dbo.InvoiceRequirements");
            DropForeignKey("dbo.InvoiceRequirements", "UserID", "dbo.Users");
            DropForeignKey("dbo.InvoiceRequirements", "InvoiceIssuedID", "dbo.InvoiceIssueds");
            DropForeignKey("dbo.InvoiceIssueds", "UserID", "dbo.Users");
            DropForeignKey("dbo.Receivables", "ActualIncomeID", "dbo.ActualIncomes");
            DropIndex("dbo.Payables", new[] { "UserID" });
            DropIndex("dbo.Payables", new[] { "CostRequirementID" });
            DropIndex("dbo.CostRequirements", new[] { "UserID" });
            DropIndex("dbo.InvoiceIssueds", new[] { "UserID" });
            DropIndex("dbo.InvoiceIssueds", new[] { "SQNum" });
            DropIndex("dbo.InvoiceRequirements", new[] { "UserID" });
            DropIndex("dbo.InvoiceRequirements", new[] { "InvoiceIssuedID" });
            DropIndex("dbo.Receivables", new[] { "UserID" });
            DropIndex("dbo.Receivables", new[] { "InvoiceRequirementID" });
            DropIndex("dbo.Receivables", new[] { "ActualIncomeID" });
            DropIndex("dbo.ActualIncomes", new[] { "UserID" });
            DropIndex("dbo.ActualIncomes", new[] { "BankSq" });
            DropTable("dbo.Payables");
            DropTable("dbo.CostRequirements");
            DropTable("dbo.Users");
            DropTable("dbo.InvoiceIssueds");
            DropTable("dbo.InvoiceRequirements");
            DropTable("dbo.Receivables");
            DropTable("dbo.ActualIncomes");
        }
    }
}
