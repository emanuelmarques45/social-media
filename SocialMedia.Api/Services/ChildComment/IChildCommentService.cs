using SocialMedia.Classes.Dtos.ChildComment;
using SocialMedia.Classes.Interfaces.Services;
using SocialMedia.Classes.Models;

namespace SocialMedia.Api.Services.ChildComment
{
    public interface IChildCommentService : IDefaultService<ChildCommentModel, CreateChildCommentRequestDto, UpdateChildCommentRequestDto>
    {
    }
}
