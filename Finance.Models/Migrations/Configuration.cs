namespace Finance.Models.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Users;

    internal sealed class Configuration : DbMigrationsConfiguration<Finance.Models.FinanceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Finance.Models.FinanceContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            

            context.Users.AddOrUpdate(
                new User { ID = 1, Name = "管理员", Password = "1", Team = Team.IT,Position = Position.Manager },
                new User { ID = 2, Name = "黄粤波", Password = "1", Team = Team.IT, Position = Position.Manager },
                new User { ID = 3, Name = "李轩", Password = "1", Team = Team.IT, Position = Position.Manager }
                );

            context.InvoiceRequirements.AddOrUpdate(
                new InvoiceRequirement
                {
                    ID = 1,
                    Amount = 0,
                    CreateTime = DateTime.Parse("2019-12-12"),
                    UserID = 1,
                    Title = "未申请开票",
                    Note = "默认保留数据,所有应收账款新建时, 默认未申请开票",
                    InvoiceIssuedID = 1
                }
                );

            context.CostRequirements.AddOrUpdate(
                new CostRequirement
                {
                    ID = 1,
                    TotalAmount = 0,
                    CreateTime = DateTime.Parse("2019-12-12"),
                    UserID = 1,
                    Receiver = "未申请付款",
                    Note = "默认保留数据, 所有应付账款新建时, 默认未申请付款",
                    CurrencyType = 0,
                }
                );

            context.InvoiceIssueds.AddOrUpdate(
                new InvoiceIssued
                {
                    ID = 1,
                     Amount =0,
                     CreateTime = DateTime.Parse("2019-12-12"),
                    UserID = 1,
                     IssuedDate = DateTime.Parse("2019-12-12"),
                      SQNum = "00000000",
                      Note = "未开具的发票, 仅作占位用"
                }
                );
        }
    }
}
