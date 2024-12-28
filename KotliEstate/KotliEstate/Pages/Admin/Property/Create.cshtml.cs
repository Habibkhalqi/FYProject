using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KotliEstate.Data;
using KotliEstate.Model;
using KotliEstate.Service;

namespace KotliEstate.Pages.Admin.Property
{
    public class CreateModel : PageModel
    {
        private IWebHostEnvironment env;
        private readonly KotliEstate.Data.AppDbContext _context;

        public CreateModel(KotliEstate.Data.AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            this.env = env;
        }

        public List<Model.category> category { get; set; }
        public IActionResult OnGet()
        {
            category = _context.tbl_category.ToList();
            return Page();
        }

        [BindProperty]
        public property property { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            string ImageName = property.picture.FileName.ToString();
            
            property.picture.CopyTo(Helper.UploadImage(ImageName, "property", env));
            
            property.image = ImageName;
            _context.tbl_property.Add(property);
            _context.SaveChanges();
            return RedirectToPage("./Index");
        }
    }
}
