﻿using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Api.Dtos.Account
{
    public class RegisterRequestDto
    {
        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(40, MinimumLength = 4)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(16, MinimumLength = 5)]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [StringLength(16, MinimumLength = 8)]
        public string Password { get; set; } = string.Empty;
    }
}