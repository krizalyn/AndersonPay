using BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AndersonPayEntity
{
    [Table("Client")]
    public class EClient : EBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClientId { get; set; }
        public int Code { get; set; }
        public string Address { get; set; }
        public int CompanyId { get; set; }
        public int RegistrationNumber { get; set; }
        [ForeignKey("TaxType")]
        public int TaxTypeId { get; set; }
        public int WithHoldingTaxPercentage { get; set; }

        public string CurrencyCode { get; set; }
        public string Name { get; set;}

        public  ETaxType TaxType { get; set; }


    }
}
