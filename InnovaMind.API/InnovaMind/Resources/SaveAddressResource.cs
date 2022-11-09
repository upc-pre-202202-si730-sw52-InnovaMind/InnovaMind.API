using System.ComponentModel.DataAnnotations;

namespace InnovaMind.API.InnovaMind.Resources;
public class SaveAddressResource
{
    [Required]
    public int UserId { get; set; }
    
    [Required]
    [MaxLength(500)]
    public string NameAddress { get; set; }

    
}
