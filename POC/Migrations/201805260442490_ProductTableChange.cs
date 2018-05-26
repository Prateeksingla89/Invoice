namespace POC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductTableChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Discription", c => c.String(maxLength: 500));
            AddColumn("dbo.Products", "price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Products", "price");
            DropColumn("dbo.Products", "Discription");
        }
    }
}
