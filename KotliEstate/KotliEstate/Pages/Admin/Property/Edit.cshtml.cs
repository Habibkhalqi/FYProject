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

namespace KotliEstate.Pages.Admin.Property
{
    public class EditModel : PageModel
    {
        private readonly KotliEstate.Data.AppDbContext _context;
        
        IWebHostEnvironment _env;      
        public EditModel(KotliEstate.Data.AppDbContext context , IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [BindProperty]
        public property property { get; set; } = default!;
        public List<Model.category> Category { get; set; }

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

            Category = _context.tbl_category.ToList();
             property =  await _context.tbl_property.FirstOrDefaultAsync(m => m.id == id);
            if (property == null)
            {
                return NotFound();
            }
          
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (property.picture != null)
            {
                string ImageName = property.picture.FileName.ToString();
                property.picture.CopyTo(Helper.UploadImage(ImageName,"property", _env));
                Helper.DeleteImage(property.image,"property",_env);

                _context.tbl_property.Update(property);
               
                _context.SaveChanges();
            }
            else
            {
                _context.tbl_property.Update(property);
                _context.SaveChanges();
            }
            return RedirectToPage("./Index");
        }
    }
}
