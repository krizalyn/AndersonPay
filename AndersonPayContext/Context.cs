using AndersonPayEntity;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AndersonPayContext
{
    public class Context : DbContext
    {
        public Context() : base("AndersonPay")
        {
            if (Database.Exists())
            {
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Migrations.Configuration>());
            }
            else
            {
                Database.SetInitializer(new DBInitializer());
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

        //To Do: Use Capital Letters on non private properties

        public DbSet<EArchive> Archives { get; set; }
        public DbSet<ECompany> companies { get; set; }
        public DbSet<EEmployee> Employees { get; set; }
        public DbSet<EFileDetail> FileDetails { get; set; }
        public DbSet<EInvoice> invoices { get; set; }
        public DbSet<EJobs> jobs { get; set; }
        public DbSet<EManpowerFile> ManpowerFiles { get; set; }
        public DbSet<EManpower> Manpowers { get; set; }
        public DbSet<EMultipleService> MultipleServices { get; set; }
        public DbSet<ETypeOfService> typeofservices { get; set; }
        public DbSet<EClient> Client { get; set; }
        public DbSet<ETaxType> TaxType { get; set; }

    }
}
