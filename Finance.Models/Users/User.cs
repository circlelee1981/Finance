using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Finance.Models.Users
{
    public class User //: BaseModel
    {
        public User()
        {
            ActualIncomes = new List<ActualIncome>();
            CostRequirements = new List<CostRequirement>();
            CostRequirementInvoiceReceiveds = new List<CostRequirementInvoiceReceived>();
            InvoiceIssueds = new List<InvoiceIssued>();
            InvoiceReceiveds = new List<InvoiceReceived>();
            InvoiceRequirements = new List<InvoiceRequirement>();
            Payables = new List<Payable>();
            Receivables = new List<Receivable>();
        }

        public int ID { get; set; }


        public string Name { get; set; }

        public string Password { get; set; }

        public Team Team { get; set; }

        public Position Position { get; set; }

        public bool IsRemoved { get; set; }

        public List<ActualIncome> ActualIncomes { get; set; }
        public List<CostRequirement> CostRequirements { get; set; }
        public List<CostRequirementInvoiceReceived> CostRequirementInvoiceReceiveds { get; set; }
        public List<InvoiceIssued> InvoiceIssueds { get; set; }
        public List<InvoiceReceived> InvoiceReceiveds { get; set; }
        public List<InvoiceRequirement> InvoiceRequirements { get; set; }
        public List<Payable> Payables { get; set; }
        public List<Receivable> Receivables { get; set; }

    }
}
