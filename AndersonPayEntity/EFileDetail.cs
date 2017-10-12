using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndersonPayEntity
{
    [Table("FileDetail")]
    public class EFileDetail
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
        public Guid Id { get; set; }

        public int SupportId { get; set; }

        public string FileName { get; set; }
        public string Extension { get; set; }

        public virtual EArchive Support { get; set; }
    }
}
