using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KotliEstate.Pages.Admin;

public class Index : PageModel
{
    public void OnGet()
    {
        if(HttpContext.Session.GetString("flag") != "true")
        {
            Response.Redirect("/Admin/Login");
        }
        ViewData["Name"] = HttpContext.Session.GetString("User");
    }
}