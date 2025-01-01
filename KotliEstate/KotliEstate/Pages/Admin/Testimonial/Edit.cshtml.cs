using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KotliEstate.Data;
using KotliEstate.Model;
using KotliEstate.Service;

namespace KotliEstate.Pages.Admin.Testimonial
{
    public class EditModel : PageModel
    {
        private readonly KotliEstate.Data.AppDbContext _context;
        private IWebHostEnvironment env;

        public EditModel(KotliEstate.Data.AppDbContext context , IWebHostEnvironment env)
        {
            _context = context;
            this.env = env;
        }

        [BindProperty]
        public testimonial testimonial { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if(HttpContext.Session.GetString("flag") != "true")
            {
                return RedirectToPage("/Admin/Login");
            }
            if (id == null)
            {
                return NotFound();
            }

             testimonial =  await _context.tbl_testimonial.FirstOrDefaultAsync(m => m.Id == id);
            if (testimonial == null)
            {
                return NotFound();
            }
           
            return Page();
        }

        public IActionResult OnPost()
        {
            if (testimonial.Picture != null)
            {
                string ImageName = testimonial.Picture.FileName.ToString();
                testimonial.Picture.CopyTo(    Helper.UploadImage(ImageName, "testimonial",env));
                Helper.DeleteImage(testimonial.Image,"testimonial",env);
                testimonial.Image = ImageName;
                _context.tbl_testimonial.Update(testimonial);
                _context.SaveChanges();
                
            }
            else
            {
                _context.tbl_testimonial.Update(testimonial);
                _context.SaveChanges();
            }
            return RedirectToPage("./Index");
        }
    }
}
