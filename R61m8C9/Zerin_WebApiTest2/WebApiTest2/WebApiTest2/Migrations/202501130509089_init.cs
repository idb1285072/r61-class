namespace WebApiTest2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Doctors");
            CreateTable(
                "dbo.Degrees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AchievementDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DoctorDegrees",
                c => new
                    {
                        DoctorID = c.Int(nullable: false, identity: true),
                        DegreeId = c.Int(nullable: false),
                        Institute = c.String(),
                        Date = c.DateTime(nullable: false),
                        Result = c.String(),
                    })
                .PrimaryKey(t => t.DoctorID)
                .ForeignKey("dbo.Degrees", t => t.DegreeId, cascadeDelete: true)
                .Index(t => t.DegreeId);
            
            CreateTable(
                "dbo.Institutes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ContactName = c.String(),
                        Email = c.String(),
                        Contact = c.String(),
                        Type = c.Int(nullable: false),
                        Address = c.String(),
                        Logo = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PatientAppointments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DoctorID = c.Int(nullable: false),
                        PatientID = c.Int(nullable: false),
                        Email = c.String(),
                        Date = c.DateTime(nullable: false),
                        Isvisited = c.Boolean(nullable: false),
                        DoctorFee = c.Double(nullable: false),
                        InsTituteID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Doctors", t => t.DoctorID, cascadeDelete: true)
                .ForeignKey("dbo.Institutes", t => t.InsTituteID, cascadeDelete: false)
                .ForeignKey("dbo.Patients", t => t.PatientID, cascadeDelete: true)
                .Index(t => t.DoctorID)
                .Index(t => t.PatientID)
                .Index(t => t.InsTituteID);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Contact = c.String(),
                        Address = c.String(),
                        Picture = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            DropColumn("dbo.Doctors", "DrId");
            AddColumn("dbo.Doctors", "ID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Doctors", "DesignationID", c => c.Int(nullable: true));
            AddColumn("dbo.Doctors", "InstituteID", c => c.Int(nullable: true));
            AddPrimaryKey("dbo.Doctors", "ID");
            CreateIndex("dbo.Doctors", "DesignationID");
            CreateIndex("dbo.Doctors", "InstituteID");
            AddForeignKey("dbo.Doctors", "DesignationID", "dbo.Designations", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Doctors", "InstituteID", "dbo.Institutes", "ID", cascadeDelete: true);
           
            DropColumn("dbo.Doctors", "Designation");
            DropColumn("dbo.Doctors", "Degree");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Doctors", "Degree", c => c.String());
            AddColumn("dbo.Doctors", "Designation", c => c.String());
            AddColumn("dbo.Doctors", "DrId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.PatientAppointments", "PatientID", "dbo.Patients");
            DropForeignKey("dbo.PatientAppointments", "InsTituteID", "dbo.Institutes");
            DropForeignKey("dbo.PatientAppointments", "DoctorID", "dbo.Doctors");
            DropForeignKey("dbo.Doctors", "InstituteID", "dbo.Institutes");
            DropForeignKey("dbo.Doctors", "DesignationID", "dbo.Designations");
            DropForeignKey("dbo.DoctorDegrees", "DegreeId", "dbo.Degrees");
            DropIndex("dbo.PatientAppointments", new[] { "InsTituteID" });
            DropIndex("dbo.PatientAppointments", new[] { "PatientID" });
            DropIndex("dbo.PatientAppointments", new[] { "DoctorID" });
            DropIndex("dbo.Doctors", new[] { "InstituteID" });
            DropIndex("dbo.Doctors", new[] { "DesignationID" });
            DropIndex("dbo.DoctorDegrees", new[] { "DegreeId" });
            DropPrimaryKey("dbo.Doctors");
            DropColumn("dbo.Doctors", "InstituteID");
            DropColumn("dbo.Doctors", "DesignationID");
            DropColumn("dbo.Doctors", "ID");
            DropTable("dbo.Patients");
            DropTable("dbo.PatientAppointments");
            DropTable("dbo.Institutes");
            DropTable("dbo.DoctorDegrees");
            DropTable("dbo.Designations");
            DropTable("dbo.Degrees");
            AddPrimaryKey("dbo.Doctors", "DrId");
        }
    }
}
