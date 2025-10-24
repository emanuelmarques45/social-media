using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SocialMedia.Api.Models;

[Table("CommentLike")]
[Index("CommentId", Name = "IX_CommentLike_CommentId")]
[Index("UserId", Name = "IX_CommentLike_UserId")]
public partial class CommentLike
{
    [Key]
    public int Id { get; set; }

    public int CommentId { get; set; }

    public string UserId { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    [ForeignKey("CommentId")]
    [InverseProperty("CommentLikes")]
    public virtual Comment Comment { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("CommentLikes")]
    public virtual AppUser User { get; set; } = null!;
}
