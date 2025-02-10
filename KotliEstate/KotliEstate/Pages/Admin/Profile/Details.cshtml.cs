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

        public Contact Contact { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.tbl_contact.FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                return NotFound();
            }
            else
            {
                Contact = contact;
            }
            return RedirectToPage("./ShowPages");
        }
    }
}
