using Finance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.DAL
{
    public class InvoiceRequirementService : BaseService<InvoiceRequirement>
    {
        public InvoiceRequirementService(FinanceContext financeContext) : base(financeContext)
        {
        }
    }
}
