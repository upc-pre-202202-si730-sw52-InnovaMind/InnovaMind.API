using InnovaMind.API.Security.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace InnovaMind.API.InnovaMind.Resources;
public class SaveSocialNetworkResource
{ 

    [Required]
    public int UserId { get; set; }
    [MaxLength(100)]
    public string NameSocialNetwork { get; set; }
    [MaxLength(500)]
    public string UrlSocialNetwork { get; set; }

}
