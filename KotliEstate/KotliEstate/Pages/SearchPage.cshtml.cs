using System.CodeDom;
using KotliEstate.Data;
using KotliEstate.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KotliEstate.Pages;

public class SearchPage : PageModel
{
    private AppDbContext db;
    public List<property> SearchProperty { get; set; } = new();
    public SearchPage(AppDbContext db)
    {
        this.db = db;
    }
    
    public void OnPost(string SearchedKeyword, string SelectCatergory)
    {
        SearchProperty = db.tbl_property.Where(x=> x.Title.Contains(SearchedKeyword) && x.Category==SelectCatergory).ToList();
        if (SearchProperty.Count>0)
        {
            ViewData["flag"] = "true";
        }
       
    }
}