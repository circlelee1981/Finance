using Finance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

namespace Finance.BLL
{
    public class InvoiceReceivedManagement : BaseManagement<InvoiceReceived>
    {
        public InvoiceReceivedManagement(FinanceContext context) : base(context)
        {
        }

        public override async Task<List<InvoiceReceived>> GetAllIncludeAll()
        {
            //throw new NotImplementedException();
            return await context.InvoiceReceiveds.Where(x => x.IsRemoved)
                .Include(x => x.CostRequirementInvoiceReceiveds)
                .Include(x => x.User)
                .ToListAsync();
        }
    }
}
