using InnovaMind.API.Security.Domain.Models;

namespace InnovaMind.API.InnovaMind.Resources;
public class SocialNetworkResource
{
    public int Id { get; set; }
    public string NameSocialNetwork { get; set; }
    public string UrlSocialNetwork { get; set; }

    //Relationships
    public User User { get; set; }
}
