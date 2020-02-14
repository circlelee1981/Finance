using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Models
{
    /// <summary>
    /// 付款申请
    /// </summary>
    public class CostRequirement:BaseModel
    {
        public CostRequirement()
        {
            Payables = new List<Payable>();
            CostRequirementInvoiceReceiveds = new List<CostRequirementInvoiceReceived>();
        }


        //[Required, ForeignKey(nameof(ReceiverAccount))]
        //public int ReceiverAccountID { get; set; }
        //public ReceiverAccount ReceiverAccount { get; set; }
        //俊宏确认, 财务得到信息, 是从客户的情况说明中获取的, 避免我们自己填错...
        [Required, MaxLength(60)]
        public string Receiver { get; set; }


        [Required, DataType(DataType.Currency)]
        public decimal TotalAmount { get; set; }

        [Required]
        public CurrencyType CurrencyType { get; set; } //考虑在多项时, 对其中某一项对方允许货币转换后支付


        //[Required]
        //public bool IsInAdvance { get; set; } = false;



        public List<Payable> Payables { get; set; } //一次付款申请, 可以一次结清多笔应付账款

       

        public List<CostRequirementInvoiceReceived> CostRequirementInvoiceReceiveds { get; set; }
        //一次付款申请, 可以针对对方的多张发票一起申请付款
        //另一方面, 对方针对我司的多次付款, 可以合并开一张发票(铁路就这么干)
        //所以实际上, 是多对多关系, 用户界面必须引导到一个新的中间模型, 新开一个界面


        //在付款申请生成后, 没有提交自动就让财务审核了, 财务审核会根据发票和debitnote情况, 判定能否预付或者发票未齐全而不付款, 



    }
}
