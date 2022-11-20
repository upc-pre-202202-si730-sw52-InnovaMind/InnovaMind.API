using System.ComponentModel.DataAnnotations;

namespace InnovaMind.API.InnovaMind.Resources;
public class SaveLicenseResource
{


    [Required]
    [MaxLength(50)]
    public string Gategory { get;set;}
    [Required]
    [MaxLength(500)]
    public string Description { get; set; }


}
