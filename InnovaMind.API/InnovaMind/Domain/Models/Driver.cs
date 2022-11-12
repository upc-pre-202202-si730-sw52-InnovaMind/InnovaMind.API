using System.Text.Json.Serialization;
using InnovaMind.API.Security.Domain.Models;
namespace InnovaMind.API.InnovaMind.Domain.Models;
public class Driver
{
    public int Id { get; set; }

    //Relationships
    public int UserId { get; set; }
    public User User { get; set; }
    [JsonIgnore]
    public Driverprofile Driverprofile { get; set; }
}
