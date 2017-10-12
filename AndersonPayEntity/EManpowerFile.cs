using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndersonPayEntity
{
    [Table("ManpowerFile")]
    public class EManpowerFile
    {
        /* 
         TO DO:
         Use identity as primary key
         Removed error messages
         Removed properties that are irelevant
         Use Capital Letters on non private properties
         Remove [Display(Name = "Name")]
             */

        public Guid Id { get; set; }

        public int ManpowerId { get; set; }

        public string Filename { get; set; }
        public string Annex { get; set; }

        public virtual EManpower Verify { get; set; }
    }
}
