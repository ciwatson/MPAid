namespace MPAid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Copy", "Audio_SingleFileId", "dbo.SingleFile");
            DropForeignKey("dbo.Copy", "RecordingId", "dbo.Recording");
            DropIndex("dbo.Copy", new[] { "RecordingId" });
            DropIndex("dbo.Copy", new[] { "Audio_SingleFileId" });
            RenameColumn(table: "dbo.Copy", name: "Audio_SingleFileId", newName: "AudioId");
            RenameColumn(table: "dbo.Copy", name: "Video_SingleFileId", newName: "VideoId");
            RenameColumn(table: "dbo.Copy", name: "RecordingId", newName: "AudioRecording_RecordingId");
            RenameIndex(table: "dbo.Copy", name: "IX_Video_SingleFileId", newName: "IX_VideoId");
            AddColumn("dbo.Recording", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Recording", "Video_CopyId", c => c.Int());
            AlterColumn("dbo.Copy", "AudioRecording_RecordingId", c => c.Int());
            AlterColumn("dbo.Copy", "AudioId", c => c.Int(nullable: false));
            CreateIndex("dbo.Recording", "Video_CopyId");
            CreateIndex("dbo.Copy", "AudioId");
            CreateIndex("dbo.Copy", "AudioRecording_RecordingId");
            AddForeignKey("dbo.Recording", "Video_CopyId", "dbo.Copy", "CopyId");
            AddForeignKey("dbo.Copy", "AudioId", "dbo.Recording", "RecordingId", cascadeDelete: true);
            AddForeignKey("dbo.Copy", "AudioRecording_RecordingId", "dbo.Recording", "RecordingId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Copy", "AudioRecording_RecordingId", "dbo.Recording");
            DropForeignKey("dbo.Copy", "AudioId", "dbo.Recording");
            DropForeignKey("dbo.Recording", "Video_CopyId", "dbo.Copy");
            DropIndex("dbo.Copy", new[] { "AudioRecording_RecordingId" });
            DropIndex("dbo.Copy", new[] { "AudioId" });
            DropIndex("dbo.Recording", new[] { "Video_CopyId" });
            AlterColumn("dbo.Copy", "AudioId", c => c.Int());
            AlterColumn("dbo.Copy", "AudioRecording_RecordingId", c => c.Int(nullable: false));
            DropColumn("dbo.Recording", "Video_CopyId");
            DropColumn("dbo.Recording", "Discriminator");
            RenameIndex(table: "dbo.Copy", name: "IX_VideoId", newName: "IX_Video_SingleFileId");
            RenameColumn(table: "dbo.Copy", name: "AudioRecording_RecordingId", newName: "RecordingId");
            RenameColumn(table: "dbo.Copy", name: "VideoId", newName: "Video_SingleFileId");
            RenameColumn(table: "dbo.Copy", name: "AudioId", newName: "Audio_SingleFileId");
            CreateIndex("dbo.Copy", "Audio_SingleFileId");
            CreateIndex("dbo.Copy", "RecordingId");
            AddForeignKey("dbo.Copy", "RecordingId", "dbo.Recording", "RecordingId", cascadeDelete: true);
            AddForeignKey("dbo.Copy", "Audio_SingleFileId", "dbo.SingleFile", "SingleFileId");
        }
    }
}
