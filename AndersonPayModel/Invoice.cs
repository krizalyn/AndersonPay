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
        public int InvoiceId { get; set; }

        public decimal AmountDue { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Tax { get; set; }

        public string TaxTypes { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public string Recipients { get; set; }
        //public string Comments { get; set; }

        public EClient Client { get; set; }

        public virtual List<EService> Services { get; set; }
        public string SINo { get; set; }
        public string TIN { get; set; }

        public string Address { get; set; }
        
        public string CreatedDate { get; set; }
        //public DateTime DueDate { get; set; }

        public int ClientId { get; set; }
      

        //public bool? Deleted { get; set; }
        //public bool Multiple { get; set; }
        //public decimal Subtotal { get; set; }
        //public DateTime? Date { get; set; }
        //public DateTime? DueDate { get; set; }
        //public DateTime? ExpiringPeriod { get; set; }
        //public DateTime? StartPeriod { get; set; }
        //public string Description { get; set; }
        //public string LateFee { get; set; }
        //public string Quantity { get; set; }
        //public string Rate { get; set; }
        //public string Status { get; set; }
        //public string TypeOfService { get; set; }


    }
}
