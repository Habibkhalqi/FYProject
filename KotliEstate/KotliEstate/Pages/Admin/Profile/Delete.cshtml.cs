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
    public class DeleteModel : PageModel
    {
        private readonly KotliEstate.Data.AppDbContext _context;

        public DeleteModel(KotliEstate.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.tbl_contact.FindAsync(id);
            if (contact != null)
            {
                Contact = contact;
                _context.tbl_contact.Remove(Contact);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./List");
        }
    }
}
