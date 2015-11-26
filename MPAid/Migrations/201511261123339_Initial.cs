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
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 64),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Word",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 64),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Recording",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Address = c.String(nullable: false, maxLength: 256),
                        Name = c.String(nullable: false, maxLength: 64),
                        Speaker_Id = c.Int(),
                        Word_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Speaker", t => t.Speaker_Id)
                .ForeignKey("dbo.Word", t => t.Word_Id)
                .Index(t => t.Speaker_Id)
                .Index(t => t.Word_Id);
            
            CreateTable(
                "dbo.Speaker",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 64),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recording", "Word_Id", "dbo.Word");
            DropForeignKey("dbo.Recording", "Speaker_Id", "dbo.Speaker");
            DropForeignKey("dbo.Word", "Category_Id", "dbo.Category");
            DropIndex("dbo.Recording", new[] { "Word_Id" });
            DropIndex("dbo.Recording", new[] { "Speaker_Id" });
            DropIndex("dbo.Word", new[] { "Category_Id" });
            DropTable("dbo.Speaker");
            DropTable("dbo.Recording");
            DropTable("dbo.Word");
            DropTable("dbo.Category");
        }
    }
}
