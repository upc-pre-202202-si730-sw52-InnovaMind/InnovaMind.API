using System.ComponentModel.DataAnnotations;

namespace InnovaMind.API.InnovaMind.Resources;
public class SaveAddressResource
{
    [Required]
    [MaxLength(255)]
    public string address { get; set; }

    [Required]
    public int userId { get; set; }
}
