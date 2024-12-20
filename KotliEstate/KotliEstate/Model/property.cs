using System.ComponentModel.DataAnnotations.Schema;

namespace KotliEstate.Model;

public class property
{
    public int id { get; set; }
    public string Title { get; set; }
    public string  Price { get; set; }
    public string Address { get; set; }
    public string Category { get; set; }
    public string  Area { get; set; }
    public string Number_Of_Bedrooms { get; set; }
    public string Number_Of_Bathrooms { get; set; }
    public string image { get; set; }
    [NotMapped]
    public IFormFile picture { get; set; }
}