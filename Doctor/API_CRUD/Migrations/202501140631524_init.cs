namespace API_CRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Degrees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DoctorsDegrees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DoctorId = c.Int(nullable: false),
                        DegreeId = c.Int(nullable: false),
                        InstituteName = c.String(),
                        AchievementDate = c.DateTime(nullable: false),
                        Grade = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Degrees", t => t.DegreeId, cascadeDelete: true)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .Index(t => t.DoctorId)
                .Index(t => t.DegreeId);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DesignationId = c.Int(nullable: false),
                        Name = c.String(),
                        DoctorDesignation = c.String(),
                        Picture = c.String(),
                        InstituteName = c.String(),
                        RegNo = c.String(),
                        EntryDate = c.DateTime(nullable: false),
                        DoctorDegree = c.String(),
                        Salary = c.Double(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Designations", t => t.DesignationId, cascadeDelete: true)
                .Index(t => t.DesignationId);
            
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PatientAppointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DoctorId = c.Int(nullable: false),
                        PatientId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        IsVisited = c.Boolean(nullable: false),
                        DoctorFee = c.Double(nullable: false),
                        InstituteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.DoctorId)
                .Index(t => t.PatientId);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Contact = c.String(),
                        Address = c.String(),
                        Picture = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Institutes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ContactName = c.String(),
                        Email = c.String(),
                        Contact = c.String(),
                        Address = c.String(),
                        Type = c.Int(nullable: false),
                        Logo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DoctorsDegrees", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.PatientAppointments", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.PatientAppointments", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Doctors", "DesignationId", "dbo.Designations");
            DropForeignKey("dbo.DoctorsDegrees", "DegreeId", "dbo.Degrees");
            DropIndex("dbo.PatientAppointments", new[] { "PatientId" });
            DropIndex("dbo.PatientAppointments", new[] { "DoctorId" });
            DropIndex("dbo.Doctors", new[] { "DesignationId" });
            DropIndex("dbo.DoctorsDegrees", new[] { "DegreeId" });
            DropIndex("dbo.DoctorsDegrees", new[] { "DoctorId" });
            DropTable("dbo.Institutes");
            DropTable("dbo.Patients");
            DropTable("dbo.PatientAppointments");
            DropTable("dbo.Designations");
            DropTable("dbo.Doctors");
            DropTable("dbo.DoctorsDegrees");
            DropTable("dbo.Degrees");
        }
    }
}
