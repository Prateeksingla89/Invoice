namespace POC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productPriceAdd1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InvoiceLines", "CustomerDescription", c => c.String());
            DropColumn("dbo.InvoiceLines", "CustomeDescription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InvoiceLines", "CustomeDescription", c => c.String());
            DropColumn("dbo.InvoiceLines", "CustomerDescription");
        }
    }
}
