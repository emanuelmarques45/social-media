using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SocialMedia.Api.Models;

[Table("ChildCommentLike")]
[Index("ChildCommentId", Name = "IX_ChildCommentLike_ChildCommentId")]
[Index("UserId", Name = "IX_ChildCommentLike_UserId")]
public partial class ChildCommentLike
{
    [Key]
    public int Id { get; set; }

    public int ChildCommentId { get; set; }

    public string UserId { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    [ForeignKey("ChildCommentId")]
    [InverseProperty("ChildCommentLikes")]
    public virtual ChildComment ChildComment { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("ChildCommentLikes")]
    public virtual AppUser User { get; set; } = null!;
}
