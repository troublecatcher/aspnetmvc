namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class frf : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        Surname = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Patro = c.String(nullable: false),
                        Sex = c.String(),
                        DOB = c.DateTime(nullable: false),
                        Address = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        Remarks = c.String(),
                        CustomerID_CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Customers", t => t.CustomerID_CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID_CustomerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "CustomerID_CustomerID", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "CustomerID_CustomerID" });
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
        }
    }
}
