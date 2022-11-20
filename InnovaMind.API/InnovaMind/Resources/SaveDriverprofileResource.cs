using System.ComponentModel.DataAnnotations;

namespace InnovaMind.API.InnovaMind.Resources;

public class SaveDriverprofileResource
{

    [Required]
    public int DriverId { get; set; }
    [Required]
    public int LicenseId { get; set; }

}