namespace InnovaMind.API.InnovaMind.Domain.Models;
public class Address
{
    public string id { get; set; }
    public string address { get; set; }

    //Relationships
    public int userId { get; set; }

    public User user { get; set; }

}
