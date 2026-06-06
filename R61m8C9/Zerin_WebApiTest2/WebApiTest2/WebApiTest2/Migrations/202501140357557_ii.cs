namespace WebApiTest2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ii : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.DoctorDegrees");
            //DropPrimaryKey("dbo.DoctorDegrees");
            //AddColumn("dbo.DoctorDegrees", "ID", c => c.Int(nullable: false, identity: false));
            //AlterColumn("dbo.DoctorDegrees", "DoctorID", c => c.Int(nullable: false, identity: false));
            //AddPrimaryKey("dbo.DoctorDegrees", "ID");
            //CreateIndex("dbo.DoctorDegrees", "ID");
            //AddForeignKey("dbo.DoctorDegrees", "DoctorID", "dbo.Doctors", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DoctorDegrees", "DoctorID", "dbo.Doctors");
            DropIndex("dbo.DoctorDegrees", new[] { "DoctorID" });
            DropPrimaryKey("dbo.DoctorDegrees");
            AlterColumn("dbo.DoctorDegrees", "DoctorID", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.DoctorDegrees", "ID");
            AddPrimaryKey("dbo.DoctorDegrees", "DoctorID");
        }
    }
}
