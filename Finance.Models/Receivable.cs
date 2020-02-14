using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Models
{

    //实际业务中, 客户可能一票内的应收账款分好几次汇款, 也可能好多票的应收账款一次实际付款, 所以不能把应收放入实收的明细, 或者倒过来也不行
    //本系统逻辑中, 一个实收可以对应多个应收, 但一个应收只能对应一个实收, 如果一个应收对应一个以上的实收, 则应该把应收分拆...

    /// <summary>
    /// 应收账款
    /// </summary>
    public class Receivable : BaseModel
    {
        private string collectionItem;

        [Required, MaxLength(60), Display(Name = "业务单号")]
        public string SalesWorkNo { get; set; }

        [Required, MaxLength(40), Display(Name = "货主")]
        public string Merchant { get; set; }

        [Required, MaxLength(40), Display(Name = "船东")]
        public string Carrier { get; set; }

        [Required, DataType(DataType.Currency), Display(Name = "金额")]
        public decimal Amount { get; set; }

        [Required, Display(Name = "收款项目")]
        public string CollectionItem { 
            get => collectionItem;
            set {
                if (value.Replace(" ","").Contains("押金"))
                {
                    Returnable = true;
                    collectionItem = value;
                }
            }
        }

        //不排除一份应收, 被对方分几次支付, 如果真是这样, 那就把应收分拆成对应的几分吧, 就能对上了
        //如果遇到对方定期清账目才付应收账款, 而某份总有一部分未付的情况, 也是分拆这一招
        //毕竟对方分拆付款是极少数, 毕竟都是见票付款或者见通知付款, 
        //不像CostRequirementInvoiceReceived,我们申请付款和收到对方发票那样, 
        ////像铁路这种估计财务根本不理业务发生情况, 而是根据系统发车勾选开票, 就可能我们一次付款可对应多张发票, 而对方一张发票又可能对应我们多次付款的情况
        [ForeignKey(nameof(ActualIncome))] //允许为null
        public int ActualIncomeID { get; set; }
        public ActualIncome ActualIncome { get; set; }

        public bool Returnable { get; set; }
        //true时是押金, 


        [ForeignKey(nameof(InvoiceRequirement))] //允许为null
        public int InvoiceRequirementID { get; set; }
        public InvoiceRequirement InvoiceRequirement { get; set; }

    }
}
