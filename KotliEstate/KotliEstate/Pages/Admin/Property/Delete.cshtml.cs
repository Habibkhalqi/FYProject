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
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace KotliEstate.Pages.Admin.Property
{
    public class DeleteModel : PageModel
    {
        private readonly KotliEstate.Data.AppDbContext _context;
        private IWebHostEnvironment env;
        
        public DeleteModel(KotliEstate.Data.AppDbContext context , IWebHostEnvironment env)
        {
            _context = context;
            this.env = env;
        }

        [BindProperty]
        public property property { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

             property = await _context.tbl_property.FirstOrDefaultAsync(m => m.id == id);

            if (property == null)
            {
                return NotFound();
            }
           
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var property = await _context.tbl_property.FindAsync(id);
            if (property != null)
            {
                property = property;
                Helper.DeleteImage(property.image,"property",env);
                
                _context.tbl_property.Remove(property);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
