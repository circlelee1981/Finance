using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finance.Models
{

    /// <summary>
    /// 开票申请
    /// </summary>
    public class InvoiceRequirement : BaseModel
    {
        private decimal amount;
        private int taxRate;

        public InvoiceRequirement()
        {
            Receivables = new List<Receivable>();
        }

        [Required, MaxLength(60)]
        public string Title { get; set; }

        [Required, DataType(DataType.Currency)]
        public decimal Amount
        {
            get => amount;
            set
            {
                amount = value;
                Principal = Math.Round(value / (1 + TaxRate), 2);
                Tax = value - Principal;
            } // => amount = value; 
        } //这是含税金额


        [Required,Range(0,50)]
        public int TaxRate { 
            get => taxRate;
            set {
                taxRate = value;
                Principal = Math.Round(amount / (1 + value), 2);
                Tax = amount - Principal;
            } // => taxRate = value; 
        } //用0, 3, 6, 9, 11,这些整数来做税点吧, 不要用小数了

        [Required, Display(Name = "专票否")]
        public bool IsSpecialTicket { get; set; }

        [Required, DataType(DataType.Currency)]
        public decimal Tax { get; set; } //税

        [Required, DataType(DataType.Currency)]
        public decimal Principal { get; set; } //本金, 想想看, 这个还不能只是计算属性而不出现在数据库, 因为每笔的税率可能不一样


        [ForeignKey(nameof(InvoiceIssued))]
        public int InvoiceIssuedID { get; set; }
        public InvoiceIssued InvoiceIssued { get; set; }

        //为什么不针对ActualIncome开具? 因为ActualIncome可能有其他人的收款部分
        public List<Receivable> Receivables { get; set; }

    }
}