using System.ComponentModel.DataAnnotations;

namespace InnovaMind.API.InnovaMind.Resources
{
    public class SaveMessageResource
    {
        [Required]
        public int EmitterId { get; set; }

        [Required]
        public int ReceiverId { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
