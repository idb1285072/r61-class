namespace R61M6C3wORKS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentInfo",
                c => new
                    {
                        StdntID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Address = c.String(maxLength: 150),
                        Mobile = c.String(maxLength: 15),
                        Email = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.StdntID);  
        }
        
        public override void Down()
        {
            DropTable("dbo.StudentInfo");
        }
    }
}
