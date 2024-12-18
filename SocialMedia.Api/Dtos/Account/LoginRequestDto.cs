﻿using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Api.Dtos.Account
{
    public class LoginRequestDto
    {
        public string? Email { get; set; } = string.Empty;

        public string? UserName { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
