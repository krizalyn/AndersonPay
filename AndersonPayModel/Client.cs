using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AndersonPayModel
{
   public class Client : Base.Base
    {

        public int Code { get; set; }
        public int ClientId { get; set; }
        public string Address { get; set; }
        public int CompanyId { get; set; }
        public int TaxTypeId { get; set; }
        public int RegistrationNumber { get; set; }
        public int WithHoldingTaxPercentage { get; set; }
        public int Registration { get; set; }
        public int Code { get; set; }



        public string email1 { get; set; }
        public string email2 { get; set; }
        public string email3 { get; set; }

        public string Address { get; set; }
        public string CurrencyCode { get; set; }
   //     public string TaxType1 { get; set; }
        public string Name { get; set; }

        public TaxType TaxType { get; set; }
    }
}
