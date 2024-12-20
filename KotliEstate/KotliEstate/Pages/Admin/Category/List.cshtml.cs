using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KotliEstate.Data;
using KotliEstate.Model;

namespace KotliEstate.Pages.Admin.Category
{
    public class ListModel(KotliEstate.Data.AppDbContext context) : PageModel
    {
        public IList<category> category { get;set; } = default!;

        public async Task OnGetAsync()
        {
            category = await context.tbl_category.ToListAsync();
        }
    }
}
