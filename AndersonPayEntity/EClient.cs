using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndersonPayEntity
{
    [Table("Client")]
    class EClient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClientId { get; set; }
        public int CompanyId { get; set; }
        [ForeignKey("TaxType")]
        public int TaxTypeId { get; set; }
        public int WithHoldingTaxPercentage { get; set; }

        public string CurrencyCode { get; set; }
        public string Name { get; set; }

        public ETaxType TaxType { get; set; }


    }
}
