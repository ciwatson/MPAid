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
                .PrimaryKey(t => t.CategoryId);
            
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
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Recording",
                c => new
                    {
                        RecordingId = c.Int(nullable: false, identity: true),
                        Address = c.String(nullable: false, maxLength: 256),
                        Name = c.String(nullable: false, maxLength: 64),
                        SpeakerId = c.Int(nullable: false),
                        WordId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RecordingId)
                .ForeignKey("dbo.Speaker", t => t.SpeakerId, cascadeDelete: true)
                .ForeignKey("dbo.Word", t => t.WordId, cascadeDelete: true)
                .Index(t => t.SpeakerId)
                .Index(t => t.WordId);
            
            CreateTable(
                "dbo.Speaker",
                c => new
                    {
                        SpeakerId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 64),
                    })
                .PrimaryKey(t => t.SpeakerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recording", "WordId", "dbo.Word");
            DropForeignKey("dbo.Recording", "SpeakerId", "dbo.Speaker");
            DropForeignKey("dbo.Word", "CategoryId", "dbo.Category");
            DropIndex("dbo.Recording", new[] { "WordId" });
            DropIndex("dbo.Recording", new[] { "SpeakerId" });
            DropIndex("dbo.Word", new[] { "CategoryId" });
            DropTable("dbo.Speaker");
            DropTable("dbo.Recording");
            DropTable("dbo.Word");
            DropTable("dbo.Category");
        }
    }
}
