using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SocialMedia.Api.Models;

[Table("Comment")]
[Index("PostId", Name = "IX_Comment_PostId")]
[Index("UserId", Name = "IX_Comment_UserId")]
public partial class Comment
{
    [Key]
    public int Id { get; set; }

    public string Content { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int PostId { get; set; }

    public string UserId { get; set; } = null!;

    [InverseProperty("Comment")]
    public virtual ICollection<ChildComment> ChildComments { get; set; } = new List<ChildComment>();

    [InverseProperty("Comment")]
    public virtual ICollection<CommentLike> CommentLikes { get; set; } = new List<CommentLike>();

    [ForeignKey("PostId")]
    [InverseProperty("Comments")]
    public virtual Post Post { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Comments")]
    public virtual AppUser User { get; set; } = null!;
}
