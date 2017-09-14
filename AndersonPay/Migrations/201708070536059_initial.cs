namespace AndersonPay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Company", "Email", c => c.String());
            AddColumn("dbo.TypeOfService", "whTax", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Company", "ContactPerson", c => c.String(nullable: false));
            AlterColumn("dbo.Company", "Tax", c => c.String(nullable: false));
            AlterColumn("dbo.TypeOfService", "NameOfService", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TypeOfService", "NameOfService", c => c.String(nullable: false));
            AlterColumn("dbo.Company", "Tax", c => c.String());
            AlterColumn("dbo.Company", "ContactPerson", c => c.String());
            DropColumn("dbo.TypeOfService", "whTax");
            DropColumn("dbo.Company", "Email");
        }
    }
}
