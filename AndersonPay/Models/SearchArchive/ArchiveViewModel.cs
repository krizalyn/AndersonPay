using AndersonPayEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AndersonPay.Models.SearchArchive
{
    public class ArchiveViewModel
    {
        public int SupportId { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }

        public virtual ICollection<EFileDetail> FileDetails { get; set; }
    }
}