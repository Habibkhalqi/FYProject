using KotliEstate.Data;
using KotliEstate.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KotliEstate.Pages;

public class property_for_rent : PageModel
{
    public List<property> ListOfProperties { get; set; }
    private AppDbContext db;

    public property_for_rent(AppDbContext db)
    {
        this.db = db;
        ListOfProperties = db.tbl_property.Where(prop=>prop.Status=="Approved").ToList();
    }
    public void OnGet()
    {
        
    }
}