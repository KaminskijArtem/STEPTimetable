namespace TestBCSETimeTableProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Records",
                c => new
                    {
                        IdRecord = c.Int(nullable: false, identity: true),
                        WeekNumber = c.Int(nullable: false),
                        WeekDay = c.Int(nullable: false),
                        SubjOrdinalNumber = c.Int(nullable: false),
                        DateTo = c.DateTime(nullable: false),
                        DateFrom = c.DateTime(nullable: false),
                        IdGroup = c.Int(nullable: false),
                        IdSubject = c.Int(nullable: false),
                        IdLecturer = c.Int(nullable: false),
                        IdSubjectType = c.Int(nullable: false),
                        IdSubjectFor = c.Int(nullable: false),
                        IdClassroom = c.Int(nullable: false),
                        SubjectFor_Id = c.Int(),
                        SubjectType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.IdRecord)
                .ForeignKey("dbo.Classrooms", t => t.IdClassroom)
                .ForeignKey("dbo.Groups", t => t.IdGroup)
                .ForeignKey("dbo.Subjects", t => t.IdSubject)
                .ForeignKey("dbo.Lecturers", t => t.IdLecturer, cascadeDelete: false)
                .ForeignKey("dbo.SubjectFors", t => t.SubjectFor_Id)
                .ForeignKey("dbo.SubjectTypes", t => t.SubjectType_Id)
                .Index(t => t.IdGroup)
                .Index(t => t.IdSubject)
                .Index(t => t.IdLecturer)
                .Index(t => t.IdClassroom)
                .Index(t => t.SubjectFor_Id)
                .Index(t => t.SubjectType_Id);
            
            CreateTable(
                "dbo.Cancellations",
                c => new
                    {
                        IdCancellation = c.Int(nullable: false, identity: true),
                        IdRecord = c.Int(nullable: false),
                        DateTo = c.DateTime(nullable: false),
                        DateFrom = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdCancellation)
                .ForeignKey("dbo.Records", t => t.IdRecord, cascadeDelete: false)
                .Index(t => t.IdRecord);
            
            CreateTable(
                "dbo.Classrooms",
                c => new
                    {
                        IdClassroom = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Building = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdClassroom);
            
            CreateTable(
                "dbo.Lecturers",
                c => new
                    {
                        IdLecturer = c.Int(nullable: false, identity: true),
                        NameLecturer = c.String(),
                        IdChair = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdLecturer)
                .ForeignKey("dbo.Chairs", t => t.IdChair, cascadeDelete: false)
                .Index(t => t.IdChair);
            
            CreateTable(
                "dbo.Chairs",
                c => new
                    {
                        IdChair = c.Int(nullable: false, identity: true),
                        NameChair = c.String(),
                    })
                .PrimaryKey(t => t.IdChair);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        IdSubject = c.Int(nullable: false, identity: true),
                        NameSubject = c.String(),
                        IdChair = c.Int(nullable: false),
                        EduLevel = c.Int(nullable: false),
                        AbnameSubject = c.String(),
                    })
                .PrimaryKey(t => t.IdSubject)
                .ForeignKey("dbo.Chairs", t => t.IdChair, cascadeDelete: false)
                .Index(t => t.IdChair);
            
            CreateTable(
                "dbo.SubjectFors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubjectTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Records", "SubjectType_Id", "dbo.SubjectTypes");
            DropForeignKey("dbo.Records", "SubjectFor_Id", "dbo.SubjectFors");
            DropForeignKey("dbo.Records", "IdLecturer", "dbo.Lecturers");
            DropForeignKey("dbo.Records", "IdSubject", "dbo.Subjects");
            DropForeignKey("dbo.Subjects", "IdChair", "dbo.Chairs");
            DropForeignKey("dbo.Lecturers", "IdChair", "dbo.Chairs");
            DropForeignKey("dbo.Records", "IdGroup", "dbo.Groups");
            DropForeignKey("dbo.Records", "IdClassroom", "dbo.Classrooms");
            DropForeignKey("dbo.Cancellations", "IdRecord", "dbo.Records");
            DropIndex("dbo.Subjects", new[] { "IdChair" });
            DropIndex("dbo.Lecturers", new[] { "IdChair" });
            DropIndex("dbo.Cancellations", new[] { "IdRecord" });
            DropIndex("dbo.Records", new[] { "SubjectType_Id" });
            DropIndex("dbo.Records", new[] { "SubjectFor_Id" });
            DropIndex("dbo.Records", new[] { "IdClassroom" });
            DropIndex("dbo.Records", new[] { "IdLecturer" });
            DropIndex("dbo.Records", new[] { "IdSubject" });
            DropIndex("dbo.Records", new[] { "IdGroup" });
            DropTable("dbo.SubjectTypes");
            DropTable("dbo.SubjectFors");
            DropTable("dbo.Subjects");
            DropTable("dbo.Chairs");
            DropTable("dbo.Lecturers");
            DropTable("dbo.Classrooms");
            DropTable("dbo.Cancellations");
            DropTable("dbo.Records");
        }
    }
}
