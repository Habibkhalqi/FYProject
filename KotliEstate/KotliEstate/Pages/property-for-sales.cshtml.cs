using KotliEstate.Data;
using KotliEstate.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KotliEstate.Pages;

public class property_for_sales : PageModel
{
    public List<property> ListOfProperties { get; set; } = new();
    private AppDbContext db;

    public property_for_sales(AppDbContext db)
    {
        this.db = db;
        ListOfProperties = db.tbl_property.ToList();
    }
    public void OnGet()
    {
        
    }
}