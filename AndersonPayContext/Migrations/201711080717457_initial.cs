namespace AndersonPayContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Invoice", "CompanyName", "dbo.Company");
            DropForeignKey("dbo.Company", "FullName", "dbo.Employee");
            DropIndex("dbo.Company", new[] { "FullName" });
            DropIndex("dbo.Invoice", new[] { "CompanyName" });
            AddColumn("dbo.Invoice", "Client_ClientId", c => c.Int());
            AlterColumn("dbo.Invoice", "CompanyName", c => c.String(nullable: false));
            CreateIndex("dbo.Invoice", "Client_ClientId");
            AddForeignKey("dbo.Invoice", "Client_ClientId", "dbo.Client", "ClientId");
            DropTable("dbo.Company");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        CompanyName = c.String(nullable: false, maxLength: 128),
                        TelephoneNumber = c.Int(nullable: false),
                        TIN = c.Int(nullable: false),
                        Wtpercent = c.Int(nullable: false),
                        Address = c.String(nullable: false),
                        CompanyCode = c.String(nullable: false),
                        ContactPerson = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        FORDO = c.String(nullable: false),
                        Currency = c.String(),
                        FullName = c.String(maxLength: 128),
                        Email = c.String(),
                        Recipients = c.String(nullable: false),
                        Tax = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CompanyName);
            
            DropForeignKey("dbo.Invoice", "Client_ClientId", "dbo.Client");
            DropIndex("dbo.Invoice", new[] { "Client_ClientId" });
            AlterColumn("dbo.Invoice", "CompanyName", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Invoice", "Client_ClientId");
            CreateIndex("dbo.Invoice", "CompanyName");
            CreateIndex("dbo.Company", "FullName");
            AddForeignKey("dbo.Company", "FullName", "dbo.Employee", "FullName");
            AddForeignKey("dbo.Invoice", "CompanyName", "dbo.Company", "CompanyName");
        }
    }
}
