using System.ComponentModel.DataAnnotations;

namespace InnovaMind.API.InnovaMind.Resources;
public class SaveLicenseResource
{
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Gategory { get;set;}
    [Required]
    [MaxLength(500)]
    public string Description { get; set; }


}
