using InnovaMind.API.Security.Domain.Models;
using System.Text.Json.Serialization;

namespace InnovaMind.API.InnovaMind.Domain.Models;
public class SocialNetwork
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string NameSocialNetwork { get; set; }
    public string UrlSocialNetwork { get; set; }

    //Relationships
    public User User { get; set; }
}
