using System.ComponentModel.DataAnnotations;

namespace InnovaMind.API.InnovaMind.Resources;

public class SaveRecruiterResource
{
    [Required]
    public int UserId { get; set; }
    
    [Required]
    public int CompanyId { get; set; }
}