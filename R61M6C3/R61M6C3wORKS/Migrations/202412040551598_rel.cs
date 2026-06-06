namespace R61M6C3wORKS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Enrollments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        StdId = c.Int(nullable: false),
                        EnrolledDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.StudentInfo", t => t.StdId, cascadeDelete: true)
                .Index(t => t.CourseID)
                .Index(t => t.StdId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrollments", "StdId", "dbo.StudentInfo");
            DropForeignKey("dbo.Enrollments", "CourseID", "dbo.Courses");
            DropIndex("dbo.Enrollments", new[] { "StdId" });
            DropIndex("dbo.Enrollments", new[] { "CourseID" });
            DropTable("dbo.Enrollments");
        }
    }
}
