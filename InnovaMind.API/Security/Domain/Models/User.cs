using InnovaMind.API.InnovaMind.Domain.Models;
using System.Text.Json.Serialization;
namespace InnovaMind.API.Security.Domain.Models;
public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Phone { get; set; }
    public string Role { get; set; }
    public string Description { get; set; }

    

    [JsonIgnore]
    public string PasswordHash { get; set; }

    public IList<SocialNetwork> SocialNetworks { get; set; } = new List<SocialNetwork>();
    
    public IList<Address> Address { get; set; } = new List<Address>();
}