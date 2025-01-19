using KotliEstate.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace KotliEstate.Pages.Admin
{
    public class Index : PageModel
    {
        public int CountOfRent { get; set; }
        public int CountOfSales { get; set; }
        public int  CountOfNotApproved { get; set; }
        public int CountOfApproved { get; set; }
        
        public string LabelOfTypes { get; set; }
        public string CountOfTypes { get; set; }
        
        private AppDbContext db;

        public Index(AppDbContext db)
        {
            this.db = db;
        }

        public void OnGet()
        {
            // Ensure the user is logged in
            if (HttpContext.Session.GetString("flag") != "true")
            {
                Response.Redirect("/Admin/Login");
            }
            ViewData["Name"] = HttpContext.Session.GetString("User");
            
            //Barchart Data Loading Work
            //Group properties by their type and count each type.
            var propertyData = db.tbl_property
                .GroupBy(p => p.Types_Of_Properties)
                .Select(g => new
            {
                propertyType = g.Key,
                count = g.Count()
            })
                .OrderBy(p=>p.propertyType)
                .ToList();
            
            //Serialization of Data
            LabelOfTypes = JsonConvert.SerializeObject(propertyData.Select((p=>p.propertyType)));
            CountOfTypes = JsonConvert.SerializeObject(propertyData.Select((p=>p.count)));
            
            //function Calling.............
            counter();

        }

        private void counter()
        {
            CountOfRent = db.tbl_property.Where(x => x.Category == "Rent").Count();
            
            CountOfSales = db.tbl_property.Where(x => x.Category == "Sales").Count();
            
            CountOfNotApproved = db.tbl_property.Where(x => x.Status == "NotApproved").Count();
            
            CountOfApproved = db.tbl_property.Where(x => x.Status == "Approved").Count();
        }
    }
}