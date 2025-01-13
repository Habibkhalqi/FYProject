using KotliEstate.Data;
using KotliEstate.Model;
using Microsoft.AspNetCore.Mvc;

namespace KotliEstate.ViewComponents;

public class ProfileViewComponent : ViewComponent
{
    public AppDbContext db;
    public Profile profile { get; set; } = new Profile();

    public ProfileViewComponent(AppDbContext db)
    {
        this.db = db;
    }

    public IViewComponentResult Invoke()
    {
        profile = db.tbl_Profile.FirstOrDefault();
        return View(profile);
    }
}