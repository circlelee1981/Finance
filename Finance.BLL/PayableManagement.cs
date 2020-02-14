using Finance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

namespace Finance.BLL
{
    public class PayableManagement : BaseManagement<Payable>
    {
        public PayableManagement(FinanceContext context) : base(context)
        {
        }

        public override async Task<List<Payable>> GetAllIncludeAll()
        {
            //throw new NotImplementedException();
            return await context.Payables.Where(x => x.IsRemoved == false)
                .Include(x => x.User)
                .Include(x => x.CostRequirement)
                .ToListAsync();
        }
    }
}
