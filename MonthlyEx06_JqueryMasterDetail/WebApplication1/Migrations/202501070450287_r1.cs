namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class r1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SalesOrders", "Picture", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SalesOrders", "Picture", c => c.String(nullable: false));
        }
    }
}
