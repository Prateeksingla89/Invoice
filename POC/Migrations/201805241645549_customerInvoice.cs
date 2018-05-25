namespace POC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customerInvoice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "CustomerName", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Invoices", "CustomerName");
        }
    }
}
