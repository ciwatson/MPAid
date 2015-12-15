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
                        VideoId = c.Int(),
                    })
                .PrimaryKey(t => t.RecordingId)
                .ForeignKey("dbo.Speaker", t => t.SpeakerId, cascadeDelete: true)
                .ForeignKey("dbo.SingleFile", t => t.VideoId)
                .ForeignKey("dbo.Word", t => t.WordId, cascadeDelete: true)
                .Index(t => t.Name, unique: true)
                .Index(t => t.SpeakerId)
                .Index(t => t.WordId)
                .Index(t => t.VideoId);
            
            CreateTable(
                "dbo.SingleFile",
                c => new
                    {
                        SingleFileId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 64),
                        Address = c.String(nullable: false, maxLength: 256),
                        AudioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SingleFileId)
                .ForeignKey("dbo.Recording", t => t.AudioId, cascadeDelete: true)
                .Index(t => t.Name, unique: true)
                .Index(t => t.AudioId);
            
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
            DropForeignKey("dbo.Recording", "VideoId", "dbo.SingleFile");
            DropForeignKey("dbo.Recording", "SpeakerId", "dbo.Speaker");
            DropForeignKey("dbo.SingleFile", "AudioId", "dbo.Recording");
            DropForeignKey("dbo.Word", "CategoryId", "dbo.Category");
            DropIndex("dbo.Speaker", new[] { "Name" });
            DropIndex("dbo.SingleFile", new[] { "AudioId" });
            DropIndex("dbo.SingleFile", new[] { "Name" });
            DropIndex("dbo.Recording", new[] { "VideoId" });
            DropIndex("dbo.Recording", new[] { "WordId" });
            DropIndex("dbo.Recording", new[] { "SpeakerId" });
            DropIndex("dbo.Recording", new[] { "Name" });
            DropIndex("dbo.Word", new[] { "CategoryId" });
            DropIndex("dbo.Word", new[] { "Name" });
            DropIndex("dbo.Category", new[] { "Name" });
            DropTable("dbo.Speaker");
            DropTable("dbo.SingleFile");
            DropTable("dbo.Recording");
            DropTable("dbo.Word");
            DropTable("dbo.Category");
        }
    }
}
