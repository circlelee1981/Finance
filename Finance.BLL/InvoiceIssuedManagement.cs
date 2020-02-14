using Finance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

namespace Finance.BLL
{
    public class InvoiceIssuedManagement : BaseManagement<InvoiceIssued>
    {
        public InvoiceIssuedManagement(FinanceContext context) : base(context)
        {
        }

        public override async Task<List<InvoiceIssued>> GetAllIncludeAll()
        {
            //throw new NotImplementedException();
            return await context.InvoiceIssueds.Where(x => x.IsRemoved == false)
                .Include(x => x.User)
                .Include(x => x.InvoiceRequirements)
                .ToListAsync();
        }
    }
}
