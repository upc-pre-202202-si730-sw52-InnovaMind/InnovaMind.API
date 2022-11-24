using System.Runtime.InteropServices;
using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.InnovaMind.Domain.Repositories;
using InnovaMind.API.Shared.Persistence.Contexts;
using InnovaMind.API.Shared.Persistence.Repositories;

using Microsoft.EntityFrameworkCore;
namespace InnovaMind.API.InnovaMind.Persistence.Repositories;

public class PostRepository : BaseRepository, IPostRepository
{
    public PostRepository(AppDbContext context) : base(context)
    {
    }
    
    public async Task<IEnumerable<Post>> ListAsync()
    {
        return await _context.Posts
            .Include(post => post.Recruiter)
            .ToListAsync();
    }

    public async Task AddAsync(Post post)
    {
        await _context.Posts.AddAsync(post);
    }

    public async Task<Post> FindByIdAsync(int id)
    {
        return await _context.Posts
            .Include(post => post.Recruiter)
            .FirstOrDefaultAsync(post => post.Id == id);
    }

    public void Update(Post post)
    {
        _context.Posts.Update(post);
    }

    public void Remove(Post post)
    {
        _context.Posts.Remove(post);
    }
}