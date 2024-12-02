using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Api.Models;

namespace SocialMedia.Api.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : IdentityDbContext<UserModel>(dbContextOptions)
    {
        public required DbSet<PostModel> Post { get; set; }

        public required DbSet<LikeModel> Likes { get; set; }

        public required DbSet<CommentModel> Comment { get; set; }

        public required DbSet<ChildCommentModel> ChildComment { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Adjust to avoid causing multiple delete paths
            _ = builder.Entity<LikeModel>()
                .HasOne(l => l.User)
                .WithMany(u => u.Likes)
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            _ = builder.Entity<CommentModel>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            _ = builder.Entity<UserModel>()
                .ToTable("Users")
                .Ignore(u => u.TwoFactorEnabled)
                .Ignore(u => u.PhoneNumberConfirmed)
                .Ignore(u => u.LockoutEnabled);

            // modelBuilder.Seed();
        }
    }
}
