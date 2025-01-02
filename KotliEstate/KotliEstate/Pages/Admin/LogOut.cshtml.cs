using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KotliEstate.Pages.Admin;

public class LogOut : PageModel
{
    public void OnGet()
    {
        
        if(HttpContext.Session.GetString("flag") == "true")
        {
            HttpContext.Session.Clear();
            Response.Redirect("/index");
        }
    }
}