using System.ComponentModel.DataAnnotations;

namespace InnovaMind.API.InnovaMind.Resources;
public class SaveEducationResource
{

    [Required]
    [MaxLength(500)]
    public string Grade_education { get; set; }
    
    [Required]
    public int DriverprofileId { get; set; }

}