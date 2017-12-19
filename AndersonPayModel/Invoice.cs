using AndersonPayEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace AndersonPayModel
{
    public class Invoice : Base.Base
    {
        
        public bool? Deleted { get; set; }
        public bool Multiple { get; set; }

        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public decimal WithholdingTax { get; set; }
        
        public int InvoiceId { get; set; }

        public DateTime? Date { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? ExpiringPeriod { get; set; }
        public DateTime? StartPeriod { get; set; }

        public int ClientId { get; set; }
        public string CurrencyCode { get; set; } 
        public int WithHoldingTaxPercentage { get; set; }

        public string Comments { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        public string LateFee { get; set; }

        public string Quantity { get; set; }
        public string Rate { get; set; }
        public string Recipients { get; set; }
        public string Status { get; set; }

        public string TypeOfService { get; set; }

        public EClient Client { get; set; }

        public virtual List<EService> Services { get; set; }
        public string SINo { get; set; }
        public string TIN { get; set; }
      
    }
}
