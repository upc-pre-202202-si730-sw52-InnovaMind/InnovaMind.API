using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.InnovaMind.Domain.Services.Communication;

namespace InnovaMind.API.InnovaMind.Domain.Services;

public interface IPostService
{
    Task<IEnumerable<Post>> ListAsync();
    Task<PostResponse> SaveAsync(Post post);
    Task<PostResponse> UpdateAsync(int id, Post post);
    Task<PostResponse> DeleteAsync(int id);
}