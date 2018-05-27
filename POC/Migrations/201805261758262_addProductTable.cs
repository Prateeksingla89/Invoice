namespace POC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProductTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InvoiceLines", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.InvoiceLines", "ProductId");
            AddForeignKey("dbo.InvoiceLines", "ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvoiceLines", "ProductId", "dbo.Products");
            DropIndex("dbo.InvoiceLines", new[] { "ProductId" });
            DropColumn("dbo.InvoiceLines", "ProductId");
        }
    }
}
