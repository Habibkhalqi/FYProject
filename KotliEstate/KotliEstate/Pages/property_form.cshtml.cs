using KotliEstate.Data;
using KotliEstate.Model;
using KotliEstate.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Diagnostics.Internal;

namespace KotliEstate.Pages;

public class property_form : PageModel
{
    private AppDbContext db;

    private IWebHostEnvironment env;
    public List<string> type_Of_Property { get; set; } = new();
    public List<string> category { get; set; } = new();
    [BindProperty] 
    public property myProperty { get; set; } = new();
    
    public property_form(AppDbContext db, IWebHostEnvironment env)
    {
        this.db = db;
        this.env = env;
    }

    public void OnGet()
    {
        
        category = db.tbl_property.Select(t => t.Category).ToList();
        
    }

    public IActionResult OnPost()
    {
        string ImageName = myProperty.picture.FileName.ToString();
        var myStream = Helper.UploadImage(ImageName, "property", env);
        myProperty.picture.CopyTo(myStream);
        myStream.Dispose();
        myProperty.image = ImageName;
        myProperty.Status = "Not Approved";
        db.tbl_property.Add(myProperty);
        db.SaveChanges();
        return RedirectToPage("./Index");
    }
}