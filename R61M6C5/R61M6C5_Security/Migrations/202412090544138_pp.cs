namespace R61M6C5_Security.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            AddColumn("dbo.AspNetUsers", "ProfilePicPath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ProfilePicPath");
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
