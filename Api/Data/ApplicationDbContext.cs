using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Api.Models;

namespace SocialMedia.Api.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : IdentityDbContext<UserModel>(dbContextOptions)
    {
        public DbSet<PostModel> Post { get; set; }
        public DbSet<LikeModel> Likes { get; set; }
        public DbSet<CommentModel> Comment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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

            modelBuilder.Entity<UserModel>()
                .ToTable("Users")
                .Ignore(u => u.TwoFactorEnabled)
                .Ignore(u => u.PhoneNumberConfirmed)
                .Ignore(u => u.LockoutEnabled);
        }
    }
}
