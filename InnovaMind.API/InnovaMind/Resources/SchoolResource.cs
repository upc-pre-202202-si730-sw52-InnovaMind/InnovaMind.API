using InnovaMind.API.InnovaMind.Domain.Models;

namespace InnovaMind.API.InnovaMind.Resources;
public class SchoolResource
{
    public int Id { get; set; }
    public string name_school { get; set;}
    public string type { get; set; }

    public Education Education { get; set; }

    
}
