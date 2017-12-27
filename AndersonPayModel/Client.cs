using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AndersonPayModel
{
   public class Client : Base.Base
    {
        public int ClientId { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string RegistrationNo { get; set; }
        
        public string CurrencyCode { get; set; }
        public string EmailAddress { get; set; }

        public string TaxTypes { get; set; }

        public int CompanyId { get; set; }
        public int TaxTypeId { get; set; }
        public int EmailId { get; set; }
        public int WithHoldingTax { get; set; }

        public TaxType TaxType { get; set; }
    }
}
