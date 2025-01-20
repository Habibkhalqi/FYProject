using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace KotliEstate.Model;

public class property
{
    public int id { get; set; }
    public string  FirstName { get; set; }
    public string  LastName { get; set; }
    
    public string CNIC { get; set; }
    [DisplayName(displayName:"Mobile Number")]
    public string MobileNumber { get; set; }
    public string Title { get; set; }
    public string  Price { get; set; }
    public string Address { get; set; }
    public string Category { get; set; }
    public int  Area { get; set; }
    //Type eg: Shope, House , Villa
    [DisplayName(displayName:"Types Of Properties")]
    public string Types_Of_Properties { get; set; }
    
    [DisplayName(displayName:"Types Of BedRooms")]
    public int? Number_Of_Bedrooms { get; set; }
    
    [DisplayName(displayName:"Types Of BathRooms")]
    public int? Number_Of_Bathrooms { get; set; }
    //Approved or Not Approved
    public string?  Status { get; set; }      
    public string  Slug { get; set; }
    public string image { get; set; }
    [NotMapped]
    public IFormFile picture { get; set; }
}