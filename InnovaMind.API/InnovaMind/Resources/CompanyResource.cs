using InnovaMind.API.InnovaMind.Domain.Models;

namespace InnovaMind.API.InnovaMind.Resources;

public class SaveCompanyResource
{
    
    public string Name { get; set; }
    public string RUC { get; set; }
    public string Owner { get; set; }
    public string Imagen_url { get; set; }
}