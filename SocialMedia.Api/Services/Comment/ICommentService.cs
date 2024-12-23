using SocialMedia.Classes.Dtos.Comment;
using SocialMedia.Classes.Interfaces.Services;
using SocialMedia.Classes.Models;

namespace SocialMedia.Api.Services.Comment
{
    public interface ICommentService : IDefaultService<CommentModel, CreateCommentRequestDto, UpdateCommentRequestDto>
    {
    }
}
