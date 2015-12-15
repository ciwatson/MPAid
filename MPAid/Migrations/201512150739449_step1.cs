namespace MPAid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class step1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SingleFile", "AudioId", "dbo.Recording");
            DropIndex("dbo.SingleFile", new[] { "AudioId" });
            AlterColumn("dbo.SingleFile", "AudioId", c => c.Int());
            CreateIndex("dbo.SingleFile", "AudioId");
            AddForeignKey("dbo.SingleFile", "AudioId", "dbo.Recording", "RecordingId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SingleFile", "AudioId", "dbo.Recording");
            DropIndex("dbo.SingleFile", new[] { "AudioId" });
            AlterColumn("dbo.SingleFile", "AudioId", c => c.Int(nullable: false));
            CreateIndex("dbo.SingleFile", "AudioId");
            AddForeignKey("dbo.SingleFile", "AudioId", "dbo.Recording", "RecordingId", cascadeDelete: true);
        }
    }
}
