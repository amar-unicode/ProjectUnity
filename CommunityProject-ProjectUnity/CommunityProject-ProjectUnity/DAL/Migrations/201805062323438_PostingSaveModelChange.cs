namespace CommunityProject_ProjectUnity.DAL.EntityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostingSaveModelChange : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PositionQualification", newName: "QualificationPosition");
            RenameTable(name: "dbo.PostingQualification", newName: "QualificationPosting");
            DropPrimaryKey("dbo.QualificationPosition");
            DropPrimaryKey("dbo.QualificationPosting");
            CreateTable(
                "dbo.PostingApplicant",
                c => new
                    {
                        Posting_ID = c.Int(nullable: false),
                        Applicant_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Posting_ID, t.Applicant_ID })
                .ForeignKey("dbo.Posting", t => t.Posting_ID, cascadeDelete: true)
                .ForeignKey("dbo.Applicant", t => t.Applicant_ID, cascadeDelete: true)
                .Index(t => t.Posting_ID)
                .Index(t => t.Applicant_ID);
            
            AddPrimaryKey("dbo.QualificationPosition", new[] { "Qualification_ID", "Position_ID" });
            AddPrimaryKey("dbo.QualificationPosting", new[] { "Qualification_ID", "Posting_ID" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostingApplicant", "Applicant_ID", "dbo.Applicant");
            DropForeignKey("dbo.PostingApplicant", "Posting_ID", "dbo.Posting");
            DropIndex("dbo.PostingApplicant", new[] { "Applicant_ID" });
            DropIndex("dbo.PostingApplicant", new[] { "Posting_ID" });
            DropPrimaryKey("dbo.QualificationPosting");
            DropPrimaryKey("dbo.QualificationPosition");
            DropTable("dbo.PostingApplicant");
            AddPrimaryKey("dbo.QualificationPosting", new[] { "Posting_ID", "Qualification_ID" });
            AddPrimaryKey("dbo.QualificationPosition", new[] { "Position_ID", "Qualification_ID" });
            RenameTable(name: "dbo.QualificationPosting", newName: "PostingQualification");
            RenameTable(name: "dbo.QualificationPosition", newName: "PositionQualification");
        }
    }
}
