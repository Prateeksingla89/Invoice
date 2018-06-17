namespace POC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeItemNameFeild : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.InvoiceLines", "ItemName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InvoiceLines", "ItemName", c => c.String(maxLength: 255));
        }
    }
}
