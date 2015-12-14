namespace MPAid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class video : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Copy", "Audio_SingleFileId", c => c.Int());
            AddColumn("dbo.Copy", "Video_SingleFileId", c => c.Int());
            CreateIndex("dbo.Copy", "Audio_SingleFileId");
            CreateIndex("dbo.Copy", "Video_SingleFileId");
            AddForeignKey("dbo.Copy", "Audio_SingleFileId", "dbo.SingleFile", "SingleFileId");
            AddForeignKey("dbo.Copy", "Video_SingleFileId", "dbo.SingleFile", "SingleFileId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Copy", "Video_SingleFileId", "dbo.SingleFile");
            DropForeignKey("dbo.Copy", "Audio_SingleFileId", "dbo.SingleFile");
            DropIndex("dbo.Copy", new[] { "Video_SingleFileId" });
            DropIndex("dbo.Copy", new[] { "Audio_SingleFileId" });
            DropColumn("dbo.Copy", "Video_SingleFileId");
            DropColumn("dbo.Copy", "Audio_SingleFileId");
        }
    }
}
