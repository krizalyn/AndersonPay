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

        [Required(ErrorMessage = "Please input Rate")]
        public decimal Rate { get; set; }
        public decimal whTax { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int typeofserviceId { get; set; }

        [Required(ErrorMessage = "Please input the Currency")]
        public string Currency { get; set; }
        [Required(ErrorMessage = "Please Input the Service")]
        public string NameOfService { get; set; }
        [Required(ErrorMessage = "Please input a Service Description")]
        public string ServiceDescription { get; set; }
    }
}
