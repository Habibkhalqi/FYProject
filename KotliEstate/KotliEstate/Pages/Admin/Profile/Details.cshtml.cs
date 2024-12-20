using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KotliEstate.Data;
using KotliEstate.Model;

namespace KotliEstate.Pages.Admin.Profile
{
    public class DetailsModel : PageModel
    {
        private readonly KotliEstate.Data.AppDbContext _context;

        public DetailsModel(KotliEstate.Data.AppDbContext context)
        {
            _context = context;
        }

        public Model.Profile Profile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = await _context.tbl_Profile.FirstOrDefaultAsync(m => m.Id == id);
            if (profile == null)
            {
                return NotFound();
            }
            else
            {
                Profile = profile;
            }
            return Page();
        }
    }
}
