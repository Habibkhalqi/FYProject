using KotliEstate.Data;
using KotliEstate.Model;
using KotliEstate.ViewModel;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KotliEstate.Pages;

public class index : PageModel
{
    private AppDbContext db;

    public CategoryViewModel count { get; set; } = new CategoryViewModel();
    public index(AppDbContext db)
    {
        this.db = db;
    }
    public void OnGet()
    {
        Counter();
    }

    private void Counter()
    {
        count.Appartment = db.tbl_property.Where(x=> x.Types_Of_Properties=="Appartment").Count();
        count.Villa = db.tbl_property.Where(x=>x.Types_Of_Properties=="Villa").Count();
        count.Home = db.tbl_property.Where(x=>x.Types_Of_Properties=="Home").Count();
        count.Office=db.tbl_property.Where(x=>x.Types_Of_Properties=="Office").Count();
        count.Building = db.tbl_property.Where(x=>x.Types_Of_Properties=="Building").Count();
        count.TownHouse = db.tbl_property.Where(x=>x.Types_Of_Properties=="TownHouse").Count();
        count.Shop = db.tbl_property.Where(x=>x.Types_Of_Properties=="Shop").Count();
        count.Garage = db.tbl_property.Where(x=>x.Types_Of_Properties=="Garage").Count();
    }
}