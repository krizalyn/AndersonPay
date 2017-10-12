namespace AndersonPay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.MultipleServices", "SubTotal");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MultipleServices", "SubTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
