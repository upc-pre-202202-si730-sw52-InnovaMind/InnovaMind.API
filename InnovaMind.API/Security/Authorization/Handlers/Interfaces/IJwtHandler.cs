using InnovaMind.API.Security.Domain.Models;
namespace InnovaMind.API.Security.Authorization.Handlers.Interfaces;

public interface IJwtHandler
{
    public string GenerateToken(User user);
    public int? ValidateToken(string token);
}
