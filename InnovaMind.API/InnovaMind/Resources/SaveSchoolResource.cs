using System.ComponentModel.DataAnnotations;

namespace InnovaMind.API.InnovaMind.Resources;
public class SaveSchoolResource
{
    
    [Required]
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string name_school { get; set;}
    [Required]
    [MaxLength(50)]
    public string type { get; set; }


    
}