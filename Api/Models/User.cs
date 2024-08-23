using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(Username), IsUnique = true)]
    public class User
    {
        [Key]
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
        public string Password { get; set; } = string.Empty;
        public DateTime CreatedAt { get; }

        //Navigation properties
        public List<Post> Posts { get; set; } = [];
        public List<Like> Likes { get; set; } = [];
        public List<Comment> Comments { get; set; } = [];
    }
}