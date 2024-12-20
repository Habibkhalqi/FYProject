using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KotliEstate.Data;
using KotliEstate.Model;

namespace KotliEstate.Pages.Admin.Category
{
    public class DeleteModel : PageModel
    {
        private readonly KotliEstate.Data.AppDbContext _context;

        public DeleteModel(KotliEstate.Data.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public category category { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.tbl_category.Add(category);
            await _context.SaveChangesAsync();

            return RedirectToPage("./List");
        }
    }
}
