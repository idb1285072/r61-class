namespace apicrud1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class iiiii : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Institutes", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Institutes", "Name");
        }
    }
}
