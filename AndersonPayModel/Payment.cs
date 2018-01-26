using BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndersonPayModel
{
    public class Payment : Base
    {
        public int PaymentId { get; set; }

        //public string DateOfPayment { get; set; }
        //public decimal AmountReceived { get; set; }
        //public decimal Payments { get; set; }
        //public decimal Discount { get; set; }
        //public decimal Balance { get; set; }

        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        public string Name { get; set; }
        public string SINo { get; set; }
        public string Description { get; set; }
    }
}
