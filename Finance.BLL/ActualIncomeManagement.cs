using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finance.Models;
using System.Data.Entity;

namespace Finance.BLL
{
    public class ActualIncomeManagement : BaseManagement<ActualIncome>
    {
        //private readonly FinanceContext context;

        public ActualIncomeManagement(FinanceContext context) : base(context)
        {
            //this.context = context;
        }

        public override async Task<List<ActualIncome>> GetAllIncludeAll()
        {

            return await context.ActualIncomes.Where(x => x.IsRemoved == false)
                .Include(x => x.User)
                .Include(x => x.Receivables)
                .ToListAsync();
        }

        

    }
}
