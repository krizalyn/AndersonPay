using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AndersonPayEntity
{
    [Table("Payment")]
    public class EReceivePayment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentId { get; set; }

        public decimal AmountReceived { get; set; }
        public string DateOfPayment { get; set; }

        //[ForeignKey("Invoice")]
        //public int InvoiceId { get; set; }

        //public EInvoice Invoice { get; set; }
    }
}
