using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KotliEstate.Data;
using KotliEstate.Model;
using KotliEstate.Service;

namespace KotliEstate.Pages.Admin.Testimonial
{
    public class DeleteModel : PageModel
    {
        private IWebHostEnvironment env; 
        private readonly KotliEstate.Data.AppDbContext _context;

        public DeleteModel(KotliEstate.Data.AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            this.env = env; 
        }

        [BindProperty]
        public testimonial testimonial { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testimonial = await _context.tbl_testimonial.FirstOrDefaultAsync(m => m.Id == id);

            if (testimonial == null)
            {
                return NotFound();
            }
            else
            {
                testimonial = testimonial;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testimonial = await _context.tbl_testimonial.FindAsync(id);
            if (testimonial != null)
            {
                testimonial = testimonial;
                Helper.DeleteImage(testimonial.Image,"testimonial",env);
                _context.tbl_testimonial.Remove(testimonial);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
