using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SocialMedia.Api.Models;

[Table("PostLike")]
[Index("PostId", Name = "IX_PostLike_PostId")]
[Index("UserId", Name = "IX_PostLike_UserId")]
public partial class PostLike
{
    [Key]
    public int Id { get; set; }

    public int PostId { get; set; }

    public string UserId { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    [ForeignKey("PostId")]
    [InverseProperty("PostLikes")]
    public virtual Post Post { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("PostLikes")]
    public virtual AppUser User { get; set; } = null!;
}
