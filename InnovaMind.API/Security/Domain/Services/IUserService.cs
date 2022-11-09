
using InnovaMind.API.Security.Domain.Models;
using InnovaMind.API.InnovaMind.Domain.Services.Communication;
using InnovaMind.API.Security.Domain.Services.Communication;

namespace InnovaMind.API.Security.Domain.Services;
public interface IUserService
{
    Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
    Task<IEnumerable<User>> ListAsync();
    Task<User> GetByIdAsync(int id);
    Task RegisterAsync(RegisterRequest model);
    Task UpdateAsync(int id, UpdateRequest model);
    Task DeleteAsync(int id);
}
