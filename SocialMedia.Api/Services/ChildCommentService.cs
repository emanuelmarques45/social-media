﻿using Microsoft.AspNetCore.Identity;
using SocialMedia.Api.Dtos.ChildComment;
using SocialMedia.Api.Interfaces.Repository;
using SocialMedia.Api.Interfaces.Services;
using SocialMedia.Api.Mappers;
using SocialMedia.Api.Models;

namespace SocialMedia.Api.Services
{
    public class ChildCommentService(IChildCommentRepository childCommentRepo, UserManager<UserModel> userManager, IPostRepository postRepo) : IChildCommentService
    {
        public async Task<ChildCommentModel?> Create(CreateChildCommentRequestDto childCommentToCreate)
        {
            var commentDb = await postRepo.GetById(childCommentToCreate.CommentId);
            var userDb = await userManager.FindByIdAsync(childCommentToCreate.UserId);

            if (commentDb == null || userDb == null)
            {
                return null;
            }

            var createdChildComment = await childCommentRepo.Create(childCommentToCreate.ToChildCommentModel());

            return createdChildComment;
        }

        public async Task<List<ChildCommentModel>> GetAll() => await childCommentRepo.GetAll();

        public async Task<ChildCommentModel?> GetById(int id) => await childCommentRepo.GetById(id);

        public async Task<ChildCommentModel?> Update(UpdateChildCommentRequestDto childCommentToUpdate)
        {
            var childCommentDb = await GetById(childCommentToUpdate.Id);

            if (childCommentDb == null)
            {
                return null;
            }

            childCommentDb.Content = childCommentToUpdate.Content;

            var updatedChildComment = await childCommentRepo.Update(childCommentDb);

            return updatedChildComment;
        }

        public async Task<ChildCommentModel?> Delete(int id)
        {
            var childCommentDb = await GetById(id);

            if (childCommentDb == null)
            {
                return null;
            }

            var deletedChildComment = await childCommentRepo.Delete(childCommentDb);

            return deletedChildComment;
        }
    }
}