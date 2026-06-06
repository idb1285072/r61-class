namespace WebApiTest2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class doc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DoctorDegrees",
                c => new
                {
                     ID = c.Int(nullable: false, identity: true),
                    DoctorID = c.Int(nullable: false ),
                    DegreeId = c.Int(nullable: false),
                    Institute = c.String(),
                    Date = c.DateTime(nullable: false),
                    Result = c.String(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Degrees", t => t.DegreeId, cascadeDelete: true)
                .Index(t => t.DegreeId)
                .ForeignKey("dbo.Doctors", t => t.DoctorID, cascadeDelete: true)
                .Index(t => t.DoctorID); 
        }
        
        public override void Down()
        {
        }
    }
}
