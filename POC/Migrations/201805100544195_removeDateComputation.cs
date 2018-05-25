namespace POC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeDateComputation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Invoices", "InvoiceDate", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Invoices", "InvoiceDate", c => c.DateTime(nullable: false, storeType: "date"));
        }
    }
}
