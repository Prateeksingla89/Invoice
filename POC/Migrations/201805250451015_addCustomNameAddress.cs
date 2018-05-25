namespace POC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCustomNameAddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "CustomerName", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Invoices", "Address", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Invoices", "Address");
            DropColumn("dbo.Invoices", "CustomerName");
        }
    }
}
