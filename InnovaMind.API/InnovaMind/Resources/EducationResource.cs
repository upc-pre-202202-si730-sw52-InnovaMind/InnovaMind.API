using InnovaMind.API.InnovaMind.Domain.Models;

namespace InnovaMind.API.InnovaMind.Resources;
public class EducationResource
{
    public int Id { get; set; }
    public string Grade_education { get; set; }

    public Driverprofile Driverprofile { get; set; }

}
