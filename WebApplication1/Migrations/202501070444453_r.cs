namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class r : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SalesOrders", "Ordernumber", c => c.String(nullable: false));
            AlterColumn("dbo.SalesOrders", "Picture", c => c.String(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SalesOrders", "Picture", c => c.String());
            AlterColumn("dbo.SalesOrders", "Ordernumber", c => c.String());
        }
    }
}
