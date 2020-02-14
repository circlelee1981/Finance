using Finance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

namespace Finance.BLL
{
    public class CostRequirementInvoiceReceivedManagement : BaseManagement<CostRequirementInvoiceReceived>
    {
        public CostRequirementInvoiceReceivedManagement(FinanceContext context) : base(context)
        {
        }

        public override async Task<List<CostRequirementInvoiceReceived>> GetAllIncludeAll()
        {
            //throw new NotImplementedException();
            return await context.CostRequirementInvoiceReceiveds.Where(x => x.IsRemoved == false)
                .Include(x => x.InvoiceReceived)
                .Include(x => x.CostRequirement)
                .Include(x => x.User)
                .ToListAsync();
        }
    }
}
