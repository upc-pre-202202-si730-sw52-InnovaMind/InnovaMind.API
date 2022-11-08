using System.ComponentModel.DataAnnotations;

namespace InnovaMind.API.InnovaMind.Resources;
public class SaveAddressResource
{
    [Required]
    [MaxLength(255)]
    public string NameAddress { get; set; }

    [Required]
    public int UserId { get; set; }
}
