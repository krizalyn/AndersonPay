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
        public int Code { get; set; }
        public string Address { get; set; }
        //public string Email1 { get; set; }
        //public string Email2 { get; set; }
        //public string Email3 { get; set; }
        public string RegistrationNumber { get; set; }
        public int CompanyId { get; set; }
        public int TaxTypeId { get; set; }
        public int WithHoldingTaxPercentage { get; set; }

        public string CurrencyCode { get; set; }
        public string Name { get; set; }

        public TaxType TaxType { get; set; }
    }
}
