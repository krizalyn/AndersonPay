using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndersonPayEntity
{
    [Table("Manpower")]
    public class EManpower
    {
        /* 
         TO DO:
         Use identity as primary key
         Removed error messages
         Removed properties that are irelevant
         Use Capital Letters on non private properties
         Remove [Display(Name = "Name")]
             */
        [Key]
        public int ManpowerId { get; set; }
        
        [Display(Name = "Detail")]
        [MaxLength(500)]
        public string Detail { get; set; }
        [Required(ErrorMessage = "Please enter the filename")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        public virtual ICollection<EManpowerFile> ManpowerFiles { get; set; }
    }
}
