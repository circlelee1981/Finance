using Finance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.DAL
{
    public class InvoiceReceivedService : BaseService<InvoiceReceived>
    {
        public InvoiceReceivedService(FinanceContext financeContext) : base(financeContext)
        {
        }
    }
}
