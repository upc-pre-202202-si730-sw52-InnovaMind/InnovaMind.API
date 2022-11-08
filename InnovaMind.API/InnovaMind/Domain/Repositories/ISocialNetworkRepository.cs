using InnovaMind.API.InnovaMind.Domain.Models;

namespace InnovaMind.API.InnovaMind.Domain.Repositories;
public interface ISocialNetworkRepository
{
    Task<IEnumerable<SocialNetwork>> ListAsync();
    Task AddAsync(SocialNetwork socialNetowork);
    Task<SocialNetwork> FindByIdAsync(int id);
    void Update(SocialNetwork socialNetowork);
    void Remove(SocialNetwork socialNetowork);
}
