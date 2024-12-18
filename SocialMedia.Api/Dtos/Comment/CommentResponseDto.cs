﻿using SocialMedia.Api.Dtos.Account;
using SocialMedia.Api.Dtos.ChildComment;

namespace SocialMedia.Api.Dtos.Comment
{
    public class CommentResponseDto
    {
        public int Id { get; set; }

        public string Content { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int PostId { get; set; }

        public RelatedAccountResponseDto User { get; set; } = null!;

        public List<ChildCommentResponseDto> Replies { get; set; } = [];
    }
}
