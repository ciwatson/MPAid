namespace MPAid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Recording",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Address = c.String(nullable: false, maxLength: 200),
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
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Word",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Type_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Type", t => t.Type_Id)
                .Index(t => t.Type_Id);
            
            CreateTable(
                "dbo.Type",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Word", "Type_Id", "dbo.Type");
            DropForeignKey("dbo.Recording", "Word_Id", "dbo.Word");
            DropForeignKey("dbo.Recording", "Speaker_Id", "dbo.Speaker");
            DropIndex("dbo.Word", new[] { "Type_Id" });
            DropIndex("dbo.Recording", new[] { "Word_Id" });
            DropIndex("dbo.Recording", new[] { "Speaker_Id" });
            DropTable("dbo.Type");
            DropTable("dbo.Word");
            DropTable("dbo.Speaker");
            DropTable("dbo.Recording");
        }
    }
}
