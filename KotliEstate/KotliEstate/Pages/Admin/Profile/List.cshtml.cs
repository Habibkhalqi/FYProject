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
    public class ListModel : PageModel
    {
        private readonly KotliEstate.Data.AppDbContext _context;

        public ListModel(KotliEstate.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Model.Profile> Profile { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Profile = await _context.tbl_Profile.ToListAsync();
        }
    }
}
