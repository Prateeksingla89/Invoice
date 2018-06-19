namespace POC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productPriceAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InvoiceLines", "CustomerDescription", c => c.String());
            AddColumn("dbo.Products", "ProductPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.InvoiceLines", "ItemDescription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InvoiceLines", "ItemDescription", c => c.String());
            DropColumn("dbo.Products", "ProductPrice");
            DropColumn("dbo.InvoiceLines", "CustomerDescription");
        }
    }
}
