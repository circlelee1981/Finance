using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity.ModelConfiguration.Conventions;
using Finance.Models.Users;

namespace Finance.Models
{
    public class FinanceContext:DbContext
    {
        public FinanceContext():base("Con")
        {
            Database.SetInitializer<FinanceContext>(null); //使用自己配置, 初始化数据库
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>(); //把一对多, 多对多级联删除, 干掉
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

        public DbSet<ActualIncome> ActualIncomes { get; set; }
        public DbSet<Receivable> Receivables { get; set; }
        public DbSet<InvoiceRequirement> InvoiceRequirements { get; set; }

        public DbSet<Payable> Payables { get; set; }
        public DbSet<CostRequirement> CostRequirements { get; set; }
        public DbSet<InvoiceIssued> InvoiceIssueds { get; set; }

        public DbSet<InvoiceReceived> InvoiceReceiveds { get; set; }

        public DbSet<CostRequirementInvoiceReceived> CostRequirementInvoiceReceiveds { get; set; }

        public DbSet<User> Users { get; set; }


    }
}
