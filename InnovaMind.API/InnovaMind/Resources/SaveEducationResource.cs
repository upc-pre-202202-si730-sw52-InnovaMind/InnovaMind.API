using System.ComponentModel.DataAnnotations;

namespace InnovaMind.API.InnovaMind.Resources;
public class SaveEducationResource
{
    [Required]
    public int Id { get; set; }
    [Required]
    [MaxLength(500)]
    public string Grade_education { get; set; }

}