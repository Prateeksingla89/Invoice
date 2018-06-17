namespace POC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class itemNameRequiredFieldRemove : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.InvoiceLines", "ItemName", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.InvoiceLines", "ItemName", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
