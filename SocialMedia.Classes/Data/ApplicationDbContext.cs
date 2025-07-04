using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Shared.Dtos.Likes;
using SocialMedia.Shared.Models;

namespace SocialMedia.Shared.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : IdentityDbContext<UserModel>(dbContextOptions)
    {
        public required DbSet<PostModel> Post { get; set; }

        public required DbSet<PostLikeModel> PostLike { get; set; }

        public required DbSet<CommentLikeModel> CommentLike { get; set; }

        public required DbSet<ChildCommentLikeModel> ChildCommentLike { get; set; }

        public required DbSet<CommentModel> Comment { get; set; }

        public required DbSet<ChildCommentModel> ChildComment { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Adjust to avoid causing multiple delete paths
            _ = builder.Entity<CommentModel>()
                  .HasOne(c => c.User)
                  .WithMany(u => u.Comments)
                  .HasForeignKey(c => c.UserId)
                  .OnDelete(DeleteBehavior.NoAction);

            _ = builder.Entity<ChildCommentModel>()
                  .HasOne(c => c.Comment)
                  .WithMany(u => u.ChildComments)
                  .HasForeignKey(c => c.CommentId)
                  .OnDelete(DeleteBehavior.NoAction);

            _ = builder.Entity<PostLikeModel>()
                .HasOne(l => l.User)
                .WithMany(u => u.Likes)
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            _ = builder.Entity<CommentLikeModel>()
                 .HasOne(l => l.Comment)
                 .WithMany(c => c.Likes)
                 .HasForeignKey(l => l.CommentId)
                 .OnDelete(DeleteBehavior.NoAction);

            _ = builder.Entity<ChildCommentLikeModel>()
                 .HasOne(l => l.ChildComment)
                 .WithMany(c => c.Likes)
                 .HasForeignKey(l => l.ChildCommentId)
                 .OnDelete(DeleteBehavior.NoAction);

            _ = builder.Entity<UserModel>()
                .ToTable("AppUser")
                .Ignore(u => u.TwoFactorEnabled)
                .Ignore(u => u.PhoneNumberConfirmed)
                .Ignore(u => u.LockoutEnabled)
                .HasMany(u => u.Followings).WithMany(u => u.Followers)
                .UsingEntity(
            fr => fr.HasOne(typeof(UserModel)).WithMany().HasForeignKey("FollowerId"),
            fg => fg.HasOne(typeof(UserModel)).WithMany().HasForeignKey("FollowingId"))
                .ToTable("Follower");

            // Auto generated data columns
            _ = builder.Entity<PostModel>()
                .Property(b => b.CreatedAt)
                .HasDefaultValueSql("getdate()");

            _ = builder.Entity<PostLikeModel>()
              .Property(b => b.CreatedAt)
              .HasDefaultValueSql("getdate()");

            _ = builder.Entity<CommentModel>()
                .Property(b => b.CreatedAt)
                .HasDefaultValueSql("getdate()");

            _ = builder.Entity<ChildCommentModel>()
                .Property(b => b.CreatedAt)
                .HasDefaultValueSql("getdate()");

            _ = builder.Entity<UserModel>()
                .Property(b => b.CreatedAt)
                .HasDefaultValueSql("getdate()");

            // modelBuilder.Seed();
        }
    }
}
