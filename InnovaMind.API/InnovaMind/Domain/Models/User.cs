namespace InnovaMind.API.InnovaMind.Domain.Models;
public class User
{
    public int id { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string description { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public string role { get; set; }

    //Relationships
    public Address address { get; set; }
}
