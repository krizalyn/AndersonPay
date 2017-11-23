using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndersonPayEntity
{
    [Table("TypeOfService")]
    public class ETypeOfService
    {
        /* 
         TO DO:
         Use identity as primary key
         Removed error messages
         Removed properties that are irelevant
         Use Capital Letters on non private properties
             */
        public bool IsSelected { get; set; }

        public string NameOfService { get; set; }

        public decimal Rate { get; set; }

        public string ServiceDescription { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TypeOfServiceId { get; set; }

        public decimal WhTax { get; set; }

        //public string Currency { get; set; }

    }
}
