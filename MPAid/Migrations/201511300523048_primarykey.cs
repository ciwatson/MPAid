namespace MPAid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class primarykey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Word", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Recording", "WordId", "dbo.Word");
            DropForeignKey("dbo.Recording", "SpeakerId", "dbo.Speaker");
            DropPrimaryKey("dbo.Category");
            DropPrimaryKey("dbo.Word");
            DropPrimaryKey("dbo.Recording");
            DropPrimaryKey("dbo.Speaker");
            AddColumn("dbo.Category", "CategoryId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Word", "WordId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Recording", "RecordingId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Speaker", "SpeakerId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Category", "CategoryId");
            AddPrimaryKey("dbo.Word", "WordId");
            AddPrimaryKey("dbo.Recording", "RecordingId");
            AddPrimaryKey("dbo.Speaker", "SpeakerId");
            AddForeignKey("dbo.Word", "CategoryId", "dbo.Category", "CategoryId", cascadeDelete: true);
            AddForeignKey("dbo.Recording", "WordId", "dbo.Word", "WordId", cascadeDelete: true);
            AddForeignKey("dbo.Recording", "SpeakerId", "dbo.Speaker", "SpeakerId", cascadeDelete: true);
            DropColumn("dbo.Category", "Id");
            DropColumn("dbo.Word", "Id");
            DropColumn("dbo.Recording", "Id");
            DropColumn("dbo.Speaker", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Speaker", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Recording", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Word", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Category", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Recording", "SpeakerId", "dbo.Speaker");
            DropForeignKey("dbo.Recording", "WordId", "dbo.Word");
            DropForeignKey("dbo.Word", "CategoryId", "dbo.Category");
            DropPrimaryKey("dbo.Speaker");
            DropPrimaryKey("dbo.Recording");
            DropPrimaryKey("dbo.Word");
            DropPrimaryKey("dbo.Category");
            DropColumn("dbo.Speaker", "SpeakerId");
            DropColumn("dbo.Recording", "RecordingId");
            DropColumn("dbo.Word", "WordId");
            DropColumn("dbo.Category", "CategoryId");
            AddPrimaryKey("dbo.Speaker", "Id");
            AddPrimaryKey("dbo.Recording", "Id");
            AddPrimaryKey("dbo.Word", "Id");
            AddPrimaryKey("dbo.Category", "Id");
            AddForeignKey("dbo.Recording", "SpeakerId", "dbo.Speaker", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Recording", "WordId", "dbo.Word", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Word", "CategoryId", "dbo.Category", "Id", cascadeDelete: true);
        }
    }
}
