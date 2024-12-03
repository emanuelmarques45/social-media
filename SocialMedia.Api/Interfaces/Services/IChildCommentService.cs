using SocialMedia.Api.Dtos.ChildComment;
using SocialMedia.Api.Models;

namespace SocialMedia.Api.Interfaces.Services
{
    public interface IChildCommentService : IDefaultService<ChildCommentModel, CreateChildCommentRequestDto, UpdateChildCommentRequestDto>
    {
    }
}
