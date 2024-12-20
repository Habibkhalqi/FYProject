using System.Data.Common;
using KotliEstate.Model;
using Microsoft.EntityFrameworkCore;

namespace KotliEstate.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Contact> tbl_contact { get; set; }
    public DbSet<Profile> tbl_Profile { get; set; }
    public DbSet<category> tbl_category { get; set; }
    public DbSet<property> tbl_property { get; set; }
    public DbSet<testimonial> tbl_testimonial { get; set; }
    
}