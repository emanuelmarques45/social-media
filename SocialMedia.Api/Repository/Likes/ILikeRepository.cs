using SocialMedia.Classes.Models;

namespace SocialMedia.Api.Repository.Likes
{
    public interface ILikeRepository : IDefaultRepository<LikeModel>
    {
        Task<LikeModel> LikePost(LikeModel likeToCreate);
    }
}
