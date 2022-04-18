namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class frff : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "CustomerID_CustomerID", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "CustomerID_CustomerID" });
            AddColumn("dbo.Orders", "CustomerID", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "CustomerID_CustomerID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "CustomerID_CustomerID", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "CustomerID");
            CreateIndex("dbo.Orders", "CustomerID_CustomerID");
            AddForeignKey("dbo.Orders", "CustomerID_CustomerID", "dbo.Customers", "CustomerID", cascadeDelete: true);
        }
    }
}
