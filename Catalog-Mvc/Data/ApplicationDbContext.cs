using Catalog_Mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalog_Mvc.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
        
        public DbSet<Category> Category { get; set; }

    
    }
}