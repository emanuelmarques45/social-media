﻿using Microsoft.AspNetCore.Identity;

namespace SocialMedia.Classes.Models
{
    public class UserModel : IdentityUser
    {
        public required string Name { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public List<PostModel> Posts { get; set; } = [];

        public List<LikeModel> Likes { get; set; } = [];

        public List<CommentModel> Comments { get; set; } = [];

        public List<UserModel> Followers { get; set; } = [];

        public List<UserModel> Followings { get; set; } = [];
    }
}