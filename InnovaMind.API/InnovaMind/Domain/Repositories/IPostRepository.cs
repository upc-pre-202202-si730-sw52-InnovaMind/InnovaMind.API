using InnovaMind.API.InnovaMind.Domain.Models;

namespace InnovaMind.API.InnovaMind.Domain.Repositories;

public interface IPostRepository
{
    Task<IEnumerable<Post>> ListAsync();
    Task AddAsync(Post post);
    Task<Post> FindByIdAsync(int id);
    void Update(Post post);
    void Remove(Post post);
}