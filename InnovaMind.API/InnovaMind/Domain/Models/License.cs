
using System.Text.Json.Serialization;

namespace InnovaMind.API.InnovaMind.Domain.Models;
public class License
{
    public int Id { get; set; }

    public string Gategory { get;set;}
    public string Description { get; set; }

    //Relationships
    [JsonIgnore]
    public Driverprofile Driverprofile { get; set; }

}
