using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KotliEstate.Data;
using KotliEstate.Model;

namespace KotliEstate.Pages.Admin.Testimonial
{
    public class IndexModel : PageModel
    {
        private readonly KotliEstate.Data.AppDbContext _context;

        public IndexModel(KotliEstate.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<testimonial> testimonial { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if(HttpContext.Session.GetString("flag") != "true")
            {
                Response.Redirect("/Admin/Login");
            }
            if(HttpContext.Session.GetString("flag") != "true")
            {
                Response.Redirect("/Admin/Login");
            }
            testimonial = await _context.tbl_testimonial.ToListAsync();
        }
    }
}
