using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SocialMedia.Api.Models;

[Table("ChildComment")]
[Index("CommentId", Name = "IX_ChildComment_CommentId")]
[Index("UserId", Name = "IX_ChildComment_UserId")]
public partial class ChildComment
{
    [Key]
    public int Id { get; set; }

    public string Content { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int CommentId { get; set; }

    public string UserId { get; set; } = null!;

    [InverseProperty("ChildComment")]
    public virtual ICollection<ChildCommentLike> ChildCommentLikes { get; set; } = new List<ChildCommentLike>();

    [ForeignKey("CommentId")]
    [InverseProperty("ChildComments")]
    public virtual Comment Comment { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("ChildComments")]
    public virtual AppUser User { get; set; } = null!;
}
