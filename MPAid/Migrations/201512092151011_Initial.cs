namespace MPAid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 64),
                    })
                .PrimaryKey(t => t.CategoryId)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Word",
                c => new
                    {
                        WordId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 64),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WordId)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.Name, unique: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Recording",
                c => new
                    {
                        RecordingId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 64),
                        SpeakerId = c.Int(nullable: false),
                        WordId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RecordingId)
                .ForeignKey("dbo.Speaker", t => t.SpeakerId, cascadeDelete: true)
                .ForeignKey("dbo.Word", t => t.WordId, cascadeDelete: true)
                .Index(t => t.Name, unique: true)
                .Index(t => t.SpeakerId)
                .Index(t => t.WordId);
            
            CreateTable(
                "dbo.Copy",
                c => new
                    {
                        CopyId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 64),
                        RecordingId = c.Int(nullable: false),
                        Audio_SingleFileId = c.Int(),
                        Video_SingleFileId = c.Int(),
                    })
                .PrimaryKey(t => t.CopyId)
                .ForeignKey("dbo.SingleFile", t => t.Audio_SingleFileId)
                .ForeignKey("dbo.Recording", t => t.RecordingId, cascadeDelete: true)
                .ForeignKey("dbo.SingleFile", t => t.Video_SingleFileId)
                .Index(t => t.Name, unique: true)
                .Index(t => t.RecordingId)
                .Index(t => t.Audio_SingleFileId)
                .Index(t => t.Video_SingleFileId);
            
            CreateTable(
                "dbo.SingleFile",
                c => new
                    {
                        SingleFileId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 64),
                        Address = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.SingleFileId)
                .ForeignKey("dbo.Copy", t => t.SingleFileId)
                .Index(t => t.SingleFileId)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Speaker",
                c => new
                    {
                        SpeakerId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 64),
                    })
                .PrimaryKey(t => t.SpeakerId)
                .Index(t => t.Name, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recording", "WordId", "dbo.Word");
            DropForeignKey("dbo.Recording", "SpeakerId", "dbo.Speaker");
            DropForeignKey("dbo.Copy", "Video_SingleFileId", "dbo.SingleFile");
            DropForeignKey("dbo.Copy", "RecordingId", "dbo.Recording");
            DropForeignKey("dbo.Copy", "Audio_SingleFileId", "dbo.SingleFile");
            DropForeignKey("dbo.SingleFile", "SingleFileId", "dbo.Copy");
            DropForeignKey("dbo.Word", "CategoryId", "dbo.Category");
            DropIndex("dbo.Speaker", new[] { "Name" });
            DropIndex("dbo.SingleFile", new[] { "Name" });
            DropIndex("dbo.SingleFile", new[] { "SingleFileId" });
            DropIndex("dbo.Copy", new[] { "Video_SingleFileId" });
            DropIndex("dbo.Copy", new[] { "Audio_SingleFileId" });
            DropIndex("dbo.Copy", new[] { "RecordingId" });
            DropIndex("dbo.Copy", new[] { "Name" });
            DropIndex("dbo.Recording", new[] { "WordId" });
            DropIndex("dbo.Recording", new[] { "SpeakerId" });
            DropIndex("dbo.Recording", new[] { "Name" });
            DropIndex("dbo.Word", new[] { "CategoryId" });
            DropIndex("dbo.Word", new[] { "Name" });
            DropIndex("dbo.Category", new[] { "Name" });
            DropTable("dbo.Speaker");
            DropTable("dbo.SingleFile");
            DropTable("dbo.Copy");
            DropTable("dbo.Recording");
            DropTable("dbo.Word");
            DropTable("dbo.Category");
        }
    }
}
