using System.Data.Entity;
using Background.Models;

namespace Background.DataBase.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("DefaultConnection")
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<Media> Medias { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //TODO делать млдель БД 

            base.OnModelCreating(modelBuilder);
        }
    }
}