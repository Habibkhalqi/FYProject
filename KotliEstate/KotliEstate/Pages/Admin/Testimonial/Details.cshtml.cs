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
    public class DetailsModel : PageModel
    {
        private readonly KotliEstate.Data.AppDbContext _context;

        public DetailsModel(KotliEstate.Data.AppDbContext context)
        {
            _context = context;
        }

        public testimonial testimonial { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Fetch the testimonial from the database
            testimonial = await _context.tbl_testimonial.FirstOrDefaultAsync(m => m.Id == id);

            if (testimonial == null)
            {
                return NotFound();
            }

            return Page();
        }

    }
}
