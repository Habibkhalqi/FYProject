using KotliEstate.Data;
using KotliEstate.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KotliEstate.Pages.Admin;
public class Login : PageModel
{
    private AppDbContext db;

    public User User1 { get; set; }

    public Login(AppDbContext db)
    {
        this.db = db;
    }
    public IActionResult OnPost()
    {
        var isUser = db.tbl_User?.Where(x=> x.Username == User1.Username && x.Password == User1.Password)
            .FirstOrDefault();
        if (isUser != null)
        {
            HttpContext.Session.SetString("User", isUser.Username);
            HttpContext.Session.SetString("flag","true");
            
            return RedirectToPage("/Admin/Index");
        }

        return Page();

    }
}