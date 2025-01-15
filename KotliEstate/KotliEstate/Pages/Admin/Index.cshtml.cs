using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace KotliEstate.Pages.Admin
{
    public class Index : PageModel
    {
        public string[] Labels { get; set; }
        public int[] Data { get; set; }

        public void OnGet()
        {
            // Ensure the user is logged in
            if (HttpContext.Session.GetString("flag") != "true")
            {
                Response.Redirect("/Admin/Login");
            }
            ViewData["Name"] = HttpContext.Session.GetString("User");

            // Provide data for the bar chart
            Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun" };
            Data = new[] { 65, 59, 80, 81, 56, 55 };
        }
    }
}