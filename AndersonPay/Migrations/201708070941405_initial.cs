namespace AndersonPay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Company", "Wtpercent", c => c.Int(nullable: false));
            AlterColumn("dbo.Jobs", "Rate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jobs", "Rate", c => c.Int(nullable: false));
            AlterColumn("dbo.Company", "Wtpercent", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
