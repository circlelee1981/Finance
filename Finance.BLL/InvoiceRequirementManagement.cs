using Finance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Finance.BLL
{
    public class InvoiceRequirementManagement : BaseManagement<InvoiceRequirement>
    {
        public InvoiceRequirementManagement(FinanceContext context) : base(context)
        {
        }

        public override async Task<List<InvoiceRequirement>> GetAllIncludeAll()
        {
            //throw new NotImplementedException();

            return await context.InvoiceRequirements.Where(x => x.IsRemoved == false)
                .Include(x => x.Receivables)
                .Include(x => x.User)
                .Include(x => x.Receivables)
                .ToListAsync();

        }
    }
}
