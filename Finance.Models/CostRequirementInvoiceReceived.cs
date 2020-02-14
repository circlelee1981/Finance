using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Models
{
    public class CostRequirementInvoiceReceived:BaseModel
    {
        [NotMapped]
        public override int ID {
            get => 0;//base.ID; 
            //set => base.ID = value; 
        }
        //此处id只是为了配合继承自BaseModel, 而已不是主键, 甚至不是数据库成员, 所以用NotMapped, 并且set都不需要


        [Key,Column(Order =1),ForeignKey(nameof(CostRequirement))]
        public int CostRequirementID { get; set; }
        public CostRequirement CostRequirement { get; set; }


        [Key,Column(Order =2),ForeignKey(nameof(InvoiceReceived))]
        public int InvoiceReceivedID { get; set; }
        public InvoiceReceived InvoiceReceived { get; set; }


        //public string Description { get; set; }


        //系统能否自动判断发票金额不齐?
        //但是预付之后, 需要补回发票, 财务怎样才能追踪呢? 
        //原本想在实收发票那里, 做一个是否预付的选项, 如果是预付则以后追踪,  但是发现比如铁路这些开票都可能和预付金额对不上的, 
        //这样根本就不能实现一一对应的核销...
        //所以只能每月, 或者年终, 按user导出该user名下, 有多少付款还没有发票
        //具体实现上, 在db.user.CostRequirementInvoiceReceiveds.select(x => new { receiver = re., difference= x.cosr.amount - ... }
        //.where(x = x.difference != 0).合计多条记录的linq语句)
    }
}
