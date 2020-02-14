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
    /// 收到对方的发票
    /// </summary>
    public class InvoiceReceived : BaseModel  //收到对方的发票
    {

        public InvoiceReceived()
        {
            CostRequirementInvoiceReceiveds = new List<CostRequirementInvoiceReceived>();
        }

        [Required, Index(IsUnique =true), MaxLength(10)]
        public string InvoiceSQNum { get; set; }


        [Required, DataType(DataType.Currency)]
        public decimal Amount { get; set; }


        //[Required]
        //public bool IsInAdvance { get; set; } = false;
        //必须有这个一个选项, 让财务审核的时候判定是否预付, 没有发票就可以付出去, 但问题是铁路后补的发票不对应你的预算假发票...
        //这种不对应, 就造成一个很麻烦的问题, 你必须允许以一种 "非一一对应关系" 的存在, 来抵消不凭发票付款的账目
        //最后这个问题, 在CostRequirementInvoiceReceived的通过user的汇总中解决, 在CostRequirementInvoiceReceived最后注释处


        public List<CostRequirementInvoiceReceived> CostRequirementInvoiceReceiveds { get; set; }
        //一个收到的发票, 可以对应多张付款申请
        //一个付款申请, 也可以由多张对方发票合并组成.
        //所以是多对多关系, 用户界面上, 需要点击后引导到一个新开窗口, 由一个中间模型来应对



    }
}
