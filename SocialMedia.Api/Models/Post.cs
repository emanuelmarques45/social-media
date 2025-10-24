using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SocialMedia.Api.Models;

[Table("Post")]
[Index("UserId", Name = "IX_Post_UserId")]
public partial class Post
{
    [Key]
    public int Id { get; set; }

    public string Content { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string UserId { get; set; } = null!;

    [InverseProperty("Post")]
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    [InverseProperty("Post")]
    public virtual ICollection<PostLike> PostLikes { get; set; } = new List<PostLike>();

    [ForeignKey("UserId")]
    [InverseProperty("Posts")]
    public virtual AppUser User { get; set; } = null!;
}
