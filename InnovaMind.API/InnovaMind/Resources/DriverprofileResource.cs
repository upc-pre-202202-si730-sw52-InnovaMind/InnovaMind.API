using InnovaMind.API.InnovaMind.Domain.Models;

namespace InnovaMind.API.InnovaMind.Resources;

public class DriverprofileResource
{
    public int Id { get; set; }
    

    public Driver Driver { get; set; }

    public License License { get; set; }
}