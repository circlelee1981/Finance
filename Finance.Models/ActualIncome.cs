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
    /// 实收账款
    /// </summary>
    public class ActualIncome:BaseModel,IBaseModel
    {
        public ActualIncome()
        {
            Receivables = new List<Receivable>();
        }

        [Required,StringLength(60),Index(IsUnique =true)]
        public string BankSq { get; set; }

        [Required, StringLength(60)]
        public string Payer { get; set; }

        [Required, StringLength(60)]
        public string PayerBankName { get; set; }


        [Required, StringLength(30)]
        public string PayerBankAccount { get; set; }

        [DataType( DataType.Currency)]
        public decimal Amount { get; set; }

        [Required]
        public CurrencyType CurrencyType { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime OccurringDate { get; set; }

        public List<Receivable> Receivables { get; set; }

    }
}
