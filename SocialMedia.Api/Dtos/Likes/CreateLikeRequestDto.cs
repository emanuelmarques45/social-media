﻿using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Api.Dtos.Likes
{
    public class CreateLikeRequestDto
    {
        [Required]
        public int PostId { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;
    }
}
