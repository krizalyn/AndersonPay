using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndersonPayEntity
{
    [Table("Archive")]
    public class EArchive
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
        [Key]
        public int SupportId { get; set; }

        [Required(ErrorMessage = "Please enter the Archive name")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Summary")]
        [MaxLength(500)]
        public string Summary { get; set; }


        public virtual ICollection<EFileDetail> FileDetails { get; set; }
    }
}
