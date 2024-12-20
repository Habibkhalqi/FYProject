using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KotliEstate.Data;
using KotliEstate.Model;

namespace KotliEstate.Pages.Admin.Category
{
    public class DetailsModel : PageModel
    {
        private readonly KotliEstate.Data.AppDbContext _context;

        public DetailsModel(KotliEstate.Data.AppDbContext context)
        {
            _context = context;
        }

        public category category { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.tbl_category.FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                category = category;
            }
            return Page();
        }
    }
}
