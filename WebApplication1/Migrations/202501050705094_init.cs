namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SalesOrderDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.SalesOrders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.SalesOrders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ordernumber = c.String(),
                        Customername = c.String(),
                        OrderDate = c.DateTime(nullable: false),
                        Picture = c.String(),
                        ISCompleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalesOrderDetails", "OrderId", "dbo.SalesOrders");
            DropForeignKey("dbo.SalesOrderDetails", "ProductId", "dbo.Products");
            DropIndex("dbo.SalesOrderDetails", new[] { "ProductId" });
            DropIndex("dbo.SalesOrderDetails", new[] { "OrderId" });
            DropTable("dbo.SalesOrders");
            DropTable("dbo.SalesOrderDetails");
            DropTable("dbo.Products");
        }
    }
}
