using System.ComponentModel.DataAnnotations;

namespace Api.Dtos.Comment
{
    public class UpdateCommentRequestDto
    {
        [StringLength(200, MinimumLength = 1)]
        public string Content { get; set; } = string.Empty;
    }
}
