using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AndersonPay.Models
{
    public class InvoiceViewModel
    {
        public int invoiceId { get; set; }
        public string CompanyName { get; set; }
        public bool Multiple { get; set; }
        public List<CheckBoxViewModel> Services { get; set; }
        public List<typeofservice> service { get; set; }
    }
}