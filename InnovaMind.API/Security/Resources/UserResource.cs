using InnovaMind.API.InnovaMind.Domain.Models;
using System.Text.Json.Serialization;

namespace InnovaMind.API.Security.Resources;

public class UserResource
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public string Role { get; set; }
    public string Description { get; set; }
}
