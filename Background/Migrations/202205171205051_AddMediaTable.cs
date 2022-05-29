namespace Background.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMediaTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Media",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Posts", "MediaId", c => c.Guid());
            AddColumn("dbo.Users", "NickName", c => c.String());
            AddColumn("dbo.Users", "MediaId", c => c.Guid());
            CreateIndex("dbo.Posts", "MediaId");
            CreateIndex("dbo.Users", "MediaId");
            AddForeignKey("dbo.Posts", "MediaId", "dbo.Media", "Id");
            AddForeignKey("dbo.Users", "MediaId", "dbo.Media", "Id");
            DropColumn("dbo.Posts", "ImagePath");
            DropColumn("dbo.Users", "Login");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Login", c => c.String());
            AddColumn("dbo.Posts", "ImagePath", c => c.String());
            DropForeignKey("dbo.Users", "MediaId", "dbo.Media");
            DropForeignKey("dbo.Posts", "MediaId", "dbo.Media");
            DropIndex("dbo.Users", new[] { "MediaId" });
            DropIndex("dbo.Posts", new[] { "MediaId" });
            DropColumn("dbo.Users", "MediaId");
            DropColumn("dbo.Users", "NickName");
            DropColumn("dbo.Posts", "MediaId");
            DropTable("dbo.Media");
        }
    }
}
