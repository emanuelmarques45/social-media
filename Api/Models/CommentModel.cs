﻿using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class CommentModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }

        //Navigation properties
        public PostModel Post { get; set; } = null!;
        public UserModel User { get; set; } = null!;
    }
}