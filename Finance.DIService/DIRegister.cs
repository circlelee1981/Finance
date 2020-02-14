using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

using Finance.Models;
//using Finance.DAL;
using Finance.BLL;
using Finance.WinformDll;

namespace Finance.DIService
{
    public static class DIRegister
    {
        //public static ServiceCollection SC { get; set; }
        public static ServiceProvider SP { get; set; }

        public static Dictionary<string, Type> DicFormType { get; set; } //= new Dictionary<string, Type> { new { Key = "1", Value = typeof(BaseFormDLL)} };

        static DIRegister() //静态类的构造函数要这样写...
        {
            var SC = new ServiceCollection();
            ServiceCollectionRegister(SC); //这里进行容器的各种注册
            SP = SC.BuildServiceProvider();

            DicFormType.Add("每日实收", typeof(BaseFormDLL));
            
        }



        public static void ServiceCollectionRegister(ServiceCollection sc)
        {
            sc.AddScoped<FinanceContext>();
            //还搞不懂, 在winform项目中, scoped的生命周期是什么?

            //BaseService是不需要注册的, 一方面它是抽象的, 无需service来创造实例, 另一方面通过派生类就能调用baseService构造函数

            //sc.AddScoped<ActualIncomeService>();
            //sc.AddScoped<CostRequirementService>();
            //sc.AddScoped<CostRequirementInvoiceReceivedService>();
            //sc.AddScoped<InvoiceIssuedService>();
            //sc.AddScoped<InvoiceReceivedService>();
            //sc.AddScoped<InvoiceRequirementService>();
            //sc.AddScoped<PayableService>();
            //sc.AddScoped<ReceivableService>();
            //sc.AddScoped<CostRequirementInvoiceReceivedService>();

            sc.AddScoped<ActualIncomeManagement>();
            sc.AddScoped<CostRequirementManagement>();
            sc.AddScoped<CostRequirementInvoiceReceivedManagement>();
            sc.AddScoped<InvoiceIssuedManagement>();
            sc.AddScoped<InvoiceReceivedManagement>();
            sc.AddScoped<InvoiceRequirementManagement>();
            sc.AddScoped<PayableManagement>();
            sc.AddScoped<ReceivableManagement>();
            sc.AddScoped<CostRequirementInvoiceReceivedManagement>();

            sc.AddTransient<BaseFormDLL>();

        }

        //public static void dosome()
        //{
        //    var ciSVC = SP.GetService<CostRequirementInvoiceReceivedService>();
        //    var ci = ciSVC.GetOneAsync(1, 1);
        //}
    }
}
