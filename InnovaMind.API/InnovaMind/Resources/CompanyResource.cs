using System.ComponentModel.DataAnnotations;

namespace InnovaMind.API.InnovaMind.Resources;

public class CompanyResource
{
    [Required]
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    [Required]
    [MaxLength(11)]
    public string RUC { get; set; }
    [Required]
    [MaxLength(100)]
    public string Owner { get; set; }
    
}