using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndersonPayEntity
{
    [Table("Payment")]
    public class EPayment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentId { get; set; }

        public string DateOfPayment { get; set; }
        public decimal AmountReceived { get; set; }
    }
}
