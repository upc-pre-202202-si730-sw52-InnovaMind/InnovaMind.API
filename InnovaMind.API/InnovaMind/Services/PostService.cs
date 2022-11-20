using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.InnovaMind.Domain.Repositories;
using InnovaMind.API.InnovaMind.Domain.Services;
using InnovaMind.API.InnovaMind.Domain.Services.Communication;
using InnovaMind.API.Shared.Domain.Repositories;

namespace InnovaMind.API.InnovaMind.Services;
public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;
    private readonly IUnitOfWork _unitOfWork;
    public PostService(IPostRepository postRepository, IUnitOfWork unitOfWork)
    {
        _postRepository = postRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<Post>> ListAsync()
    {
        return await _postRepository.ListAsync();
    }

    public async Task<PostResponse> SaveAsync(Post post)
    {
        try
        {
            await _postRepository.AddAsync(post);
            await _unitOfWork.CompleteAsync();
            return new PostResponse(post);
        }
        catch (Exception e)
        {
            return new PostResponse($"An error occurred when saving the post: {e.Message}");
        }
    }

    public async Task<PostResponse> UpdateAsync(int id, Post post)
    {
        var existingPost = await _postRepository.FindByIdAsync(id);
        if (existingPost == null)
            return new PostResponse("Post not found.");
        existingPost.RecruiterId = post.RecruiterId;
        existingPost.Title = post.Title;
        existingPost.Description = post.Description;
        existingPost.date = post.date;

        try
        {
            _postRepository.Update(post);
            await _unitOfWork.CompleteAsync();
            return new PostResponse(existingPost);
        }
        catch (Exception e)
        {
            return new PostResponse($"An error occurred when updating the post: {e.Message}");
        }
    }

    public async Task<PostResponse> DeleteAsync(int id)
    {
        var existingPost = await _postRepository.FindByIdAsync(id);
        if (existingPost == null)
            return new PostResponse("Post not found.");
        try
        {
            _postRepository.Remove(existingPost);
            await _unitOfWork.CompleteAsync();
            return new PostResponse(existingPost);
        }
        catch (Exception e)
        {
            return new PostResponse($"An error occurred when deleting the post: {e.Message}");
        }
    }
}