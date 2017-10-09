using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AndersonPay.Models
{
    public class CheckBoxViewModel
    {
        public int Id { get; set; }
        public string NameOfService { get; set; }
        public bool Checked { get; set; }

        public string ServiceQuantity { get; set; }
        public string ServiceRate { get; set; }
    }
}