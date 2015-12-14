namespace MPAid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class recording : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Copy", "Audio_SingleFileId", "dbo.SingleFile");
            DropForeignKey("dbo.Copy", "Video_SingleFileId", "dbo.SingleFile");
            DropIndex("dbo.Copy", new[] { "Audio_SingleFileId" });
            DropIndex("dbo.Copy", new[] { "Video_SingleFileId" });
            AddColumn("dbo.Recording", "Video_CopyId", c => c.Int());
            AddColumn("dbo.Copy", "Recording_RecordingId", c => c.Int());
            CreateIndex("dbo.Recording", "Video_CopyId");
            CreateIndex("dbo.Copy", "Recording_RecordingId");
            AddForeignKey("dbo.Copy", "Recording_RecordingId", "dbo.Recording", "RecordingId");
            AddForeignKey("dbo.Recording", "Video_CopyId", "dbo.Copy", "CopyId");
            DropColumn("dbo.Copy", "Audio_SingleFileId");
            DropColumn("dbo.Copy", "Video_SingleFileId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Copy", "Video_SingleFileId", c => c.Int());
            AddColumn("dbo.Copy", "Audio_SingleFileId", c => c.Int());
            DropForeignKey("dbo.Recording", "Video_CopyId", "dbo.Copy");
            DropForeignKey("dbo.Copy", "Recording_RecordingId", "dbo.Recording");
            DropIndex("dbo.Copy", new[] { "Recording_RecordingId" });
            DropIndex("dbo.Recording", new[] { "Video_CopyId" });
            DropColumn("dbo.Copy", "Recording_RecordingId");
            DropColumn("dbo.Recording", "Video_CopyId");
            CreateIndex("dbo.Copy", "Video_SingleFileId");
            CreateIndex("dbo.Copy", "Audio_SingleFileId");
            AddForeignKey("dbo.Copy", "Video_SingleFileId", "dbo.SingleFile", "SingleFileId");
            AddForeignKey("dbo.Copy", "Audio_SingleFileId", "dbo.SingleFile", "SingleFileId");
        }
    }
}
