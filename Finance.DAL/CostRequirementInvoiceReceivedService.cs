using Finance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.Linq.Expressions;


namespace Finance.DAL
{
    public class CostRequirementInvoiceReceivedService:BaseService<CostRequirementInvoiceReceived>
    {
        //private readonly FinanceContext financeContext;

        public CostRequirementInvoiceReceivedService(FinanceContext financeContext):base(financeContext)
        {
            //this.financeContext = financeContext; //这个不再需要, 因为继承的基类中已经有了
            //但是构造函数必须要写, 否则基类构造函数缺参数
        }


        //这个方法本来应该被封掉的, 但是c#好像不允许派生类更改基类成员的访问级别
        //public override async Task<CostRequirementInvoiceReceived> GetOneAsync(int id)
        //{
        //    //return await base.GetOneAsync(id);
        //    //return await Task.Run(
        //    //    () =>
        //    //    {
        //    //        return null;
        //    //    }
        //    //);


        //    //这个GetOne方法, 对于本类来说, 是失效的, 所以要封闭掉
        //    //本来想直接通过private把这个base方法封闭掉, 但是报错, 难道派生类内不能修改基类成员的访问级别? 
        //    //尝试用new, 来隐藏掉原来的方法, 并且设置private, 这样外面就访问不到这个方法了, 结果发现其实有两个GetOne方法了, 而外部能直接访问基类的方法, 
        //}

        public override Task<CostRequirementInvoiceReceived> GetOneAsync(int id)
        {
            //return base.GetOneAsync(id);
            return null;
        }


        public async Task<CostRequirementInvoiceReceived> GetOneAsync(int cid, int iid)
        {

            //错误写法, await 要写在return后面, 
            //await return this.GetWhere(x => x.CostRequirementID == cid & x.InvoiceReceivedID == iid).FirstOrDefaultAsync();
            //return await this.GetWhere(x => x.CostRequirementID == cid & x.InvoiceReceivedID == iid).FirstOrDefaultAsync();

            return await Task.Run(() =>
            {
                return this.GetWhere(x => x.CostRequirementID == cid && x.InvoiceReceivedID == iid).FirstOrDefault();
            }
            );
        }


    }


}
