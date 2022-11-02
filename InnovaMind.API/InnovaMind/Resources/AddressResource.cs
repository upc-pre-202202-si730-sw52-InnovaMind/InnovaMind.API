using InnovaMind.API.InnovaMind.Domain.Models;

namespace InnovaMind.API.InnovaMind.Resources;
public class AddressResource
{
    public int id { get; set; }
    public string address { get; set; }
    public UserResource user { get; set; }
}