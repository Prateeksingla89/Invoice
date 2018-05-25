namespace POC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCustomerAddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "Address", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Invoices", "Address");
        }
    }
}
