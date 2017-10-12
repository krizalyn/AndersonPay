using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndersonPayEntity
{
    [Table("ManpowerViewModel")]
    public class EManpowerViewModel
    {
        /* 
         TO DO:
         Use identity as primary key
         Removed error messages
         Removed properties that are irelevant
         Use Capital Letters on non private properties
         Remove [Display(Name = "Name")]
         Check why using this entity instead of directing to employees
             */

        [MaxLength(500)]
        public string Detail { get; set; }
        public string Name { get; set; }

        public List<EManpowerViewModel> Employees { get; set; }
    }
}
