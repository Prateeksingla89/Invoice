namespace POC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTaxProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Tax", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Tax");
        }
    }
}
