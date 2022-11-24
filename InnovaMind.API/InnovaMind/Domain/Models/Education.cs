using InnovaMind.API.Security.Domain.Models;
using System.Text.Json.Serialization;
namespace InnovaMind.API.InnovaMind.Domain.Models;
public class Education
{
    public int Id { get; set; }
    public string Grade_education { get; set; }

    //Relationships
    public int DriverprofileId { get; set; }
    public Driverprofile Driverprofile { get; set; }

    [JsonIgnore]
    public IList<School> Schooles { get; set; } = new List<School>();
    
    
}
