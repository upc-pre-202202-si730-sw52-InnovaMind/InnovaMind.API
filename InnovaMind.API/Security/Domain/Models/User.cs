using InnovaMind.API.InnovaMind.Domain.Models;
using System.Text.Json.Serialization;

namespace InnovaMind.API.Security.Domain.Models;
public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public string Role { get; set; }
    public string Description { get; set; }

    [JsonIgnore]
    public string PasswordHash { get; set; }

    [JsonIgnore]
    public IList<SocialNetwork> SocialNetworks { get; set; } = new List<SocialNetwork>();

    [JsonIgnore]
    public IList<Address> Addresses { get; set; } = new List<Address>();

    [JsonIgnore]
    public IList<Message> EmittedMessages { get; set; } = new List<Message>();

    [JsonIgnore]
    public IList<Message> ReceivedMessages { get; set; } = new List<Message>();
    
    public IList<Address> Address { get; set; } = new List<Address>();
    public IList<Notification> Notifications { get; set; }
    [JsonIgnore]
    public Driver Driver { get; set; } 
}