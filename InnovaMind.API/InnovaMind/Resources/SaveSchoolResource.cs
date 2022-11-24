using System.ComponentModel.DataAnnotations;

namespace InnovaMind.API.InnovaMind.Resources;
public class SaveSchoolResource
{
    

    [Required]
    [MaxLength(50)]
    public string name_school { get; set;}
    [Required]
    [MaxLength(50)]
    public string type { get; set; }
    [Required]
    public int EducationId { get; set; }


    
}