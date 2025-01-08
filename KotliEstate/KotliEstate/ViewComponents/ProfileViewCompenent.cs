using KotliEstate.Data;
using KotliEstate.Model;
using Microsoft.AspNetCore.Mvc;

namespace KotliEstate.ViewComponents;

public class ProfileViewCompenent : ViewComponent
{
    private AppDbContext db;
    public Profile Pro { get; set; } = new Profile();

    public ProfileViewCompenent(AppDbContext db)
    {
        this.db = db;
    }

    public IViewComponentResult Invoke()
    {
        Pro = db.tbl_Profile.FirstOrDefault();
        return View(Pro);
    }
}