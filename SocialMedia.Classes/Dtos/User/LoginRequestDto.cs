﻿using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Classes.Dtos.User
{
    public class LoginRequestDto
    {
        public string? Email { get; set; }

        public string? UserName { get; set; }

        [Required]
        public required string Password { get; set; }
    }
}
