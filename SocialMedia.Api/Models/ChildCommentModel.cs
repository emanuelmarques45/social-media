﻿namespace SocialMedia.Api.Models
{
    public class ChildCommentModel
    {
        public int Id { get; set; }

        public string Content { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int? CommentId { get; set; }

        public string UserId { get; set; } = string.Empty;

        public CommentModel Comment { get; set; } = null!;

        public UserModel User { get; set; } = null!;
    }
}
