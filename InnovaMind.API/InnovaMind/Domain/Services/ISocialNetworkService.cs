using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.InnovaMind.Domain.Services.Communication;

namespace InnovaMind.API.InnovaMind.Domain.Services;
public interface ISocialNetworkService
{
    Task<IEnumerable<SocialNetwork>> ListAsync();
    Task<SocialNetworkResponse> SaveAsync(SocialNetwork socialNetwork);
    Task<SocialNetworkResponse> UpdateAsync(int id, SocialNetwork socialNetwork);
    Task<SocialNetworkResponse> DeleteAsync(int id);
}
