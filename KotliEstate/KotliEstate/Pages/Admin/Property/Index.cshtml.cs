using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KotliEstate.Data;
using KotliEstate.Model;

namespace KotliEstate.Pages.Admin.Property
{
    public class IndexModel : PageModel
    {
        private readonly KotliEstate.Data.AppDbContext _context;

        public IndexModel(KotliEstate.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<property> property { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if(HttpContext.Session.GetString("flag") != "true")
            {
                Response.Redirect("/Admin/Login");
            }
            property = await _context.tbl_property.ToListAsync();
        }
    }
}
