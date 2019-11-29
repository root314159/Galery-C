namespace GaleryApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        ImageUrl = c.String(),
                        Description = c.String(),
                        Name = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Password = c.String(),
                        Name = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photos", "UserID", "dbo.Users");
            DropIndex("dbo.Photos", new[] { "UserID" });
            DropTable("dbo.Users");
            DropTable("dbo.Photos");
        }
    }
}
