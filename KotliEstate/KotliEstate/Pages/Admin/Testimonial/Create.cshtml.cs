using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KotliEstate.Data;
using KotliEstate.Model;

namespace KotliEstate.Pages.Admin.Testimonial
{
    public class CreateModel : PageModel
    {
        private readonly KotliEstate.Data.AppDbContext _context;
        private IWebHostEnvironment env;
        
        public CreateModel(KotliEstate.Data.AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            this.env = env;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty] public testimonial testimonial { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            string imagename = testimonial.Picture.FileName.ToString();
            
            var FolderPath = Path.Combine(env.WebRootPath, "uploaded_image/testimonial");
            
            var ImagePath = Path.Combine(FolderPath, imagename);
            
            var PicFileStream = new FileStream(ImagePath, FileMode.Create);
            testimonial.Picture.CopyTo(PicFileStream);
            
            testimonial.Image = imagename;
            _context.tbl_testimonial.Add(testimonial);
            _context.SaveChanges();
            return RedirectToPage("./index");
        }
    }
}
