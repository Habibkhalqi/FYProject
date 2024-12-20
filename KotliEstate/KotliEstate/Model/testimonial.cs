using System.ComponentModel.DataAnnotations.Schema;

namespace KotliEstate.Model;

public class testimonial
{
    public int  Id { get; set; }
    public string Name { get; set; }
    public string  Professional { get; set; }
    public string Review { get; set; }
    public string  Image { get; set; }
    
    [NotMapped]
    public IFormFile Picture { get; set; }
    
}