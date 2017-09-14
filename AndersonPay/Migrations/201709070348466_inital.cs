namespace AndersonPay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inital : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MultipleServices", "typeofserviceId", "dbo.TypeOfService");
            DropIndex("dbo.MultipleServices", new[] { "typeofserviceId" });
            RenameColumn(table: "dbo.MultipleServices", name: "typeofserviceId", newName: "typeofservices_typeofserviceId");
            AddColumn("dbo.Invoice", "Multiple", c => c.Boolean(nullable: false));
            AlterColumn("dbo.MultipleServices", "typeofservices_typeofserviceId", c => c.Int());
            AlterColumn("dbo.MultipleServices", "ServiceQuantity", c => c.String(nullable: false));
            AlterColumn("dbo.Invoice", "TypeOfService", c => c.String());
            AlterColumn("dbo.TypeOfService", "Rate", c => c.Int(nullable: false));
            CreateIndex("dbo.MultipleServices", "typeofservices_typeofserviceId");
            AddForeignKey("dbo.MultipleServices", "typeofservices_typeofserviceId", "dbo.TypeOfService", "typeofserviceId");
            DropColumn("dbo.MultipleServices", "ServiceDescription");
            DropColumn("dbo.TypeOfService", "Currency");
            DropColumn("dbo.TypeOfService", "ServiceDescription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TypeOfService", "ServiceDescription", c => c.String(nullable: false));
            AddColumn("dbo.TypeOfService", "Currency", c => c.String(nullable: false));
            AddColumn("dbo.MultipleServices", "ServiceDescription", c => c.String(nullable: false));
            DropForeignKey("dbo.MultipleServices", "typeofservices_typeofserviceId", "dbo.TypeOfService");
            DropIndex("dbo.MultipleServices", new[] { "typeofservices_typeofserviceId" });
            AlterColumn("dbo.TypeOfService", "Rate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Invoice", "TypeOfService", c => c.String(nullable: false));
            AlterColumn("dbo.MultipleServices", "ServiceQuantity", c => c.String());
            AlterColumn("dbo.MultipleServices", "typeofservices_typeofserviceId", c => c.Int(nullable: false));
            DropColumn("dbo.Invoice", "Multiple");
            RenameColumn(table: "dbo.MultipleServices", name: "typeofservices_typeofserviceId", newName: "typeofserviceId");
            CreateIndex("dbo.MultipleServices", "typeofserviceId");
            AddForeignKey("dbo.MultipleServices", "typeofserviceId", "dbo.TypeOfService", "typeofserviceId", cascadeDelete: true);
        }
    }
}
