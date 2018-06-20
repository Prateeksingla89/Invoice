namespace POC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TotalPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InvoiceLines", "TotalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.InvoiceLines", "TotalPrice");
        }
    }
}
