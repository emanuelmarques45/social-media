using SocialMedia.Api.Dtos.Comment;
using SocialMedia.Api.Models;

namespace SocialMedia.Api.Interfaces.Services
{
    public interface ICommentService : IDefaultService<CommentModel, CreateCommentRequestDto, UpdateCommentRequestDto>
    {
    }
}
