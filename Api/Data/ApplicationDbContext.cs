using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class ApplicationDbContext(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Comment> Commment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Like>()
                .HasOne(u => u.User)
                .WithMany(l => l.Likes)
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comment>()
                .HasOne(u => u.User)
                .WithMany(c => c.Comments)
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
