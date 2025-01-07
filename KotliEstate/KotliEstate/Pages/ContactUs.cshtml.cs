using KotliEstate.Data;
using KotliEstate.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KotliEstate.Pages;

public class ContactUs : PageModel
{
    public Profile Pro { get; set; } = new();
    [BindProperty]
    public Contact contactus { get; set; } = new();
  
    private AppDbContext db;
 
    public ContactUs(AppDbContext db)
    {
        this.db = db;
    }
    public void OnGet()
    {
        Pro = db.tbl_Profile.FirstOrDefault();
    }

    public void OnPost()
    {
        db.tbl_contact.Add(contactus);
        db.SaveChanges();
    }
}