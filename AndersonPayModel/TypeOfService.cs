using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndersonPayModel
{
   public class TypeOfService : Base.Base
    {
        public string NameOfService { get; set; }

        public decimal Rate { get; set; }

        public string ServiceDescription { get; set; }

        public int TypeOfServiceId { get; set; }

        public decimal WhTax { get; set; }


    }
}
