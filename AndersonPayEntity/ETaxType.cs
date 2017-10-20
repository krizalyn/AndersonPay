using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AndersonPayEntity
{
    [Table("TaxType")]
    class ETaxType
    {
        public int TaxTypeId { get; set; }

        public string Name { get; set; }
        
       
    }
}
