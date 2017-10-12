using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AndersonPay.Models.SearchArchive
{
    public class ArchiveResults
    {
        public string Name { get; set; }
        [MaxLength(500)]
        public string Summary { get; set; }
        public List<ArchiveViewModel> Services { get; set; }
    }
}