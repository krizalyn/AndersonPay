using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndersonPayEntity
{
    [Table("Jobs")]
    public class EJobs
    {
        /* 
         TO DO:
         Use identity as primary key
         Removed error messages
         Removed properties that are irelevant
         Use Capital Letters on non private properties
             */

        [Required(ErrorMessage = "Please Input Rate")]
        public decimal Rate { get; set; }

        [Required(ErrorMessage = "Please Input Currency")]
        public string Currency { get; set; }
        [Key]
        [Required(ErrorMessage = "Please Input Job Position")]
        public string JobName { get; set; }
        [Required(ErrorMessage = "Please Select Type of Pay")]
        public string RateType { get; set; }

    }
}
