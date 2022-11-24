using System.ComponentModel.DataAnnotations;

namespace InnovaMind.API.InnovaMind.Resources;
public class SaveDriverResource
{

    [Required]
    public int UserId { get; set; }
    
}
