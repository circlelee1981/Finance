using Finance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Finance.BLL
{
    public class ReceivableManagement : BaseManagement<Receivable>
    {
        //private readonly FinanceContext context;

        public ReceivableManagement(FinanceContext context): base(context)
        {
            //this.context = context;
        }

        public override async Task<List<Receivable>> GetAllIncludeAll()
        {
            //throw new NotImplementedException();
            return await context.Receivables.Where(x => x.IsRemoved == false)
                .Include(x => x.User)
                .Include(x => x.ActualIncome)
                .Include(x => x.InvoiceRequirement)
                .ToListAsync();
        }


    }
}
