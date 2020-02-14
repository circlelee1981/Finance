using Finance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.BLL
{
    public abstract class BaseManagement<T> where T: BaseModel, new()
    {
        protected readonly FinanceContext context;

        public BaseManagement(FinanceContext context)
        {
            this.context = context;
        }
        public abstract Task<List<T>> GetAllIncludeAll();

    }
}
