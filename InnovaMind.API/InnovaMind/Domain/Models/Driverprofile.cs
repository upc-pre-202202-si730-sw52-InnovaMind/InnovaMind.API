namespace InnovaMind.API.InnovaMind.Domain.Models;
public class Driverprofile
{
    public int Id { get; set; }
    

    //Relationships
    public int DriverId { get; set; }
    public Driver Driver { get; set; }

    public int LicenseId { get; set; }
    public License License { get; set; }
    public Education Education { get; set; }
}