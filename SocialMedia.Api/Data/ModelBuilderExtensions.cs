using Microsoft.EntityFrameworkCore;
using SocialMedia.Lib.Models;

namespace SocialMedia.Api.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var random = new Random();

            _ = modelBuilder.Entity<PostModel>().HasData(
                new PostModel
                {
                    Id = random.Next(),
                    Content = "Sample Post",
                    CreatedAt = DateTime.UtcNow,
                    UserId = "2dc7e742-81c0-47d9-a69a-cf300ee8ffd2",
                },
                new PostModel
                {
                    Id = random.Next(),
                    Content = "Sample Post",
                    CreatedAt = DateTime.UtcNow,
                    UserId = "2dc7e742-81c0-47d9-a69a-cf300ee8ffd2",
                },
                new PostModel
                {
                    Id = random.Next(),
                    Content = "Sample Post",
                    CreatedAt = DateTime.UtcNow,
                    UserId = "2dc7e742-81c0-47d9-a69a-cf300ee8ffd2",
                },
                new PostModel
                {
                    Id = random.Next(),
                    Content = "Sample Post",
                    CreatedAt = DateTime.UtcNow,
                    UserId = "2dc7e742-81c0-47d9-a69a-cf300ee8ffd2",
                });

            _ = modelBuilder.Entity<CommentModel>().HasData(
                new CommentModel
                {
                    Id = random.Next(),
                    Content = "Sample Comment",
                    CreatedAt = DateTime.UtcNow,
                    UserId = "df35deba-a1ef-44b1-aa54-9c1dfc4bb3b9",
                    PostId = 2,
                },
                new CommentModel
                {
                    Id = random.Next(),
                    Content = "Sample Comment",
                    CreatedAt = DateTime.UtcNow,
                    UserId = "df35deba-a1ef-44b1-aa54-9c1dfc4bb3b9",
                    PostId = 2,
                },
                new CommentModel
                {
                    Id = random.Next(),
                    Content = "Sample Comment",
                    CreatedAt = DateTime.UtcNow,
                    UserId = "df35deba-a1ef-44b1-aa54-9c1dfc4bb3b9",
                    PostId = 2,
                },
                new CommentModel
                {
                    Id = random.Next(),
                    Content = "Sample Comment",
                    CreatedAt = DateTime.UtcNow,
                    UserId = "df35deba-a1ef-44b1-aa54-9c1dfc4bb3b9",
                    PostId = 2,
                },
                new CommentModel
                {
                    Id = random.Next(),
                    Content = "Sample Comment",
                    CreatedAt = DateTime.UtcNow,
                    UserId = "df35deba-a1ef-44b1-aa54-9c1dfc4bb3b9",
                    PostId = 2,
                },
                new CommentModel
                {
                    Id = random.Next(),
                    Content = "Sample Comment",
                    CreatedAt = DateTime.UtcNow,
                    UserId = "df35deba-a1ef-44b1-aa54-9c1dfc4bb3b9",
                    PostId = 2,
                },
                new CommentModel
                {
                    Id = random.Next(),
                    Content = "Sample Comment",
                    CreatedAt = DateTime.UtcNow,
                    UserId = "df35deba-a1ef-44b1-aa54-9c1dfc4bb3b9",
                    PostId = 2,
                },
                new CommentModel
                {
                    Id = random.Next(),
                    Content = "Sample Comment",
                    CreatedAt = DateTime.UtcNow,
                    UserId = "df35deba-a1ef-44b1-aa54-9c1dfc4bb3b9",
                    PostId = 2,
                });
        }
    }
}
