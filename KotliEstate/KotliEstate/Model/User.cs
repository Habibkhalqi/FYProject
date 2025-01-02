using System.ComponentModel.DataAnnotations;

namespace KotliEstate.Model;

public class User
{
    public int  Id { get; set; }
    public string  Name { get; set; }
    public string Username { get; set; }
    
    [DataType(DataType.Password)]
    public string  Password { get; set; }
}