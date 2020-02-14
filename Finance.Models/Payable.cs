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
    /// 应付账款
    /// </summary>
    public class Payable:BaseModel
    {
        [Required, MaxLength(60), Display(Name ="业务单号")]
        public string SalesWorkNo { get; set; }

        //[Required, MaxLength(60)]
        //public string Receiver { get; set; } //这个在应付的时候可能定不下,到申请时才确定

        [Required,MaxLength(40),Display(Name ="货主")]
        public string Merchant { get; set; }

        [Required, MaxLength(40), Display(Name = "船东")]
        public string Carrier { get; set; }


        [DataType( DataType.Currency)]
        public decimal Amount { get; set; }

        [Required]
        public CurrencyType CurrencyType { get; set; }

        [Required, Display(Name = "收款项目")]
        public string CollectionItem { get; set; }


        [ForeignKey(nameof(CostRequirement))] //外键约束是否允许为空? 如果的确需要它可为空呢? 类型用int? 还是啥都不用管? 
        public int CostRequirementID { get; set; }
        public CostRequirement CostRequirement { get; set; }

    }
}
