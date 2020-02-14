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
    /// 我司已开具的发票
    /// </summary>
    public class InvoiceIssued:BaseModel
    {
        public InvoiceIssued()
        {
            InvoiceRequirements = new List<InvoiceRequirement>();
        }

        [Index(IsUnique =true),StringLength(10, MinimumLength =8)] //这个现在是8位, 估计5-6年后, 要搞成9位数...
        public string SQNum { get; set; } //发票号码

        //[Required, StringLength(14, MinimumLength =12)]
        //public string InvoiceCode { get; set; } //发票代码, 老实说我不知道这个和上一个有啥区别, 要一个不就行了嘛? 
        //有的时候, 扫码扫不出来的..., 所以就不要这个了

        [Required, DataType(DataType.Currency)]
        public decimal Amount { get; set; } //发票金额

        [Required, DataType(DataType.Date)]
        public DateTime IssuedDate { get; set; }


        public List<InvoiceRequirement> InvoiceRequirements { get; set; }

    }
}
