using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class ApplicationDbContext(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<PostModel> Post { get; set; }
        public DbSet<LikeModel> Likes { get; set; }
        public DbSet<CommentModel> Comment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Adjust to avoid causing multiple delete paths

            modelBuilder.Entity<LikeModel>()
                .HasOne(l => l.User)
                .WithMany(u => u.Likes)
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CommentModel>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.ClrType.GetProperties())
                {
                    if (property.Name == "CreatedAt" && property.PropertyType == typeof(DateTime))
                    {
                        modelBuilder.Entity(entityType.ClrType)
                            .Property<DateTime>(property.Name)
                            .HasDefaultValueSql("GETDATE()");
                    }
                }
            }
        }
    }
}
