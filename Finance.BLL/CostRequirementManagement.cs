using Finance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

namespace Finance.BLL
{
    public class CostRequirementManagement : BaseManagement<CostRequirement>
    {
        public CostRequirementManagement(FinanceContext context) : base(context)
        {
        }

        public override async Task<List<CostRequirement>> GetAllIncludeAll()
        {
            //throw new NotImplementedException();

            return await context.CostRequirements.Where(x => x.IsRemoved == false)
                .Include(x => x.CostRequirementInvoiceReceiveds)
                .Include(x => x.Payables)
                .Include(x => x.User)
                .ToListAsync();
        }
    }
}
