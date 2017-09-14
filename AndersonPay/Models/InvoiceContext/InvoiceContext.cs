using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AndersonPay.Models.InvoiceContext
{
    public class InvoiceContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public InvoiceContext() : base("name=InvoiceContext")
        {
        }

        public System.Data.Entity.DbSet<AndersonPay.Models.invoice> invoices { get; set; }

        public System.Data.Entity.DbSet<AndersonPay.Models.company> companies { get; set; }

        public System.Data.Entity.DbSet<AndersonPay.Models.typeofservice> typeofservices { get; set; }
        public System.Data.Entity.DbSet<AndersonPay.Models.Archive> Archives { get; set; }
        public System.Data.Entity.DbSet<AndersonPay.Models.FileDetail> FileDetails { get; set; }
        public System.Data.Entity.DbSet<AndersonPay.Models.MultipleService> MultipleServices { get; set; }

        public System.Data.Entity.DbSet<AndersonPay.Models.jobs> jobs { get; set; }

        public System.Data.Entity.DbSet<AndersonPay.Models.Employee> Employees { get; set; }
        public System.Data.Entity.DbSet<AndersonPay.Models.SearchManpower.Manpower> Manpowers { get; set; }
        public System.Data.Entity.DbSet<AndersonPay.Models.SearchManpower.ManpowerFile> ManpowerFiles { get; set; }
    }
}
