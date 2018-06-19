namespace POC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customerDiscription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "CustomerDescription", c => c.String());
            DropColumn("dbo.InvoiceLines", "CustomerDescription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InvoiceLines", "CustomerDescription", c => c.String());
            DropColumn("dbo.Invoices", "CustomerDescription");
        }
    }
}
