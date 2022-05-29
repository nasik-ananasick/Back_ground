namespace Background.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class олроб : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Description = c.String(),
                        Tags = c.String(),
                        UserId = c.Guid(nullable: false),
                        LikesCount = c.Int(nullable: false),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Reactions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PostId = c.Guid(nullable: false),
                        Content = c.String(),
                        IsLike = c.Boolean(nullable: false),
                        User_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.PostId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Login = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        IsModer = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Reactions", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Reactions", "PostId", "dbo.Posts");
            DropIndex("dbo.Reactions", new[] { "User_Id" });
            DropIndex("dbo.Reactions", new[] { "PostId" });
            DropIndex("dbo.Posts", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Reactions");
            DropTable("dbo.Posts");
        }
    }
}
