namespace MPAid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreignkey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Word", "Category_Id", "dbo.Category");
            DropForeignKey("dbo.Recording", "Word_Id", "dbo.Word");
            DropForeignKey("dbo.Recording", "Speaker_Id", "dbo.Speaker");
            DropIndex("dbo.Word", new[] { "Category_Id" });
            DropIndex("dbo.Recording", new[] { "Speaker_Id" });
            DropIndex("dbo.Recording", new[] { "Word_Id" });
            RenameColumn(table: "dbo.Word", name: "Category_Id", newName: "CategoryId");
            RenameColumn(table: "dbo.Recording", name: "Word_Id", newName: "WordId");
            RenameColumn(table: "dbo.Recording", name: "Speaker_Id", newName: "SpeakerId");
            DropPrimaryKey("dbo.Category");
            DropPrimaryKey("dbo.Word");
            DropPrimaryKey("dbo.Recording");
            DropPrimaryKey("dbo.Speaker");
            AlterColumn("dbo.Category", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Word", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Word", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Recording", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Recording", "SpeakerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Recording", "WordId", c => c.Int(nullable: false));
            AlterColumn("dbo.Speaker", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Category", "Id");
            AddPrimaryKey("dbo.Word", "Id");
            AddPrimaryKey("dbo.Recording", "Id");
            AddPrimaryKey("dbo.Speaker", "Id");
            CreateIndex("dbo.Word", "CategoryId");
            CreateIndex("dbo.Recording", "SpeakerId");
            CreateIndex("dbo.Recording", "WordId");
            AddForeignKey("dbo.Word", "CategoryId", "dbo.Category", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Recording", "WordId", "dbo.Word", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Recording", "SpeakerId", "dbo.Speaker", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recording", "SpeakerId", "dbo.Speaker");
            DropForeignKey("dbo.Recording", "WordId", "dbo.Word");
            DropForeignKey("dbo.Word", "CategoryId", "dbo.Category");
            DropIndex("dbo.Recording", new[] { "WordId" });
            DropIndex("dbo.Recording", new[] { "SpeakerId" });
            DropIndex("dbo.Word", new[] { "CategoryId" });
            DropPrimaryKey("dbo.Speaker");
            DropPrimaryKey("dbo.Recording");
            DropPrimaryKey("dbo.Word");
            DropPrimaryKey("dbo.Category");
            AlterColumn("dbo.Speaker", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Recording", "WordId", c => c.Int());
            AlterColumn("dbo.Recording", "SpeakerId", c => c.Int());
            AlterColumn("dbo.Recording", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Word", "CategoryId", c => c.Int());
            AlterColumn("dbo.Word", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Category", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Speaker", "Id");
            AddPrimaryKey("dbo.Recording", "Id");
            AddPrimaryKey("dbo.Word", "Id");
            AddPrimaryKey("dbo.Category", "Id");
            RenameColumn(table: "dbo.Recording", name: "SpeakerId", newName: "Speaker_Id");
            RenameColumn(table: "dbo.Recording", name: "WordId", newName: "Word_Id");
            RenameColumn(table: "dbo.Word", name: "CategoryId", newName: "Category_Id");
            CreateIndex("dbo.Recording", "Word_Id");
            CreateIndex("dbo.Recording", "Speaker_Id");
            CreateIndex("dbo.Word", "Category_Id");
            AddForeignKey("dbo.Recording", "Speaker_Id", "dbo.Speaker", "Id");
            AddForeignKey("dbo.Recording", "Word_Id", "dbo.Word", "Id");
            AddForeignKey("dbo.Word", "Category_Id", "dbo.Category", "Id");
        }
    }
}
