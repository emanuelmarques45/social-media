using Api.Models;
using System.ComponentModel.DataAnnotations;

namespace Api.Dtos.User
{
    public class UserDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(40, MinimumLength = 4)]
        public string Email { get; set; } = string.Empty;
        [Required]
        [StringLength(16)]
        public string Username { get; set; } = string.Empty;
        [Required]
        [StringLength(16)]
        public DateTime CreatedAt { get; }

        public List<Post> Posts { get; set; } = [];
        public List<Like> Likes { get; set; } = [];
        public List<Comment> Comments { get; set; } = [];
    }
}