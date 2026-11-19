using Microsoft.EntityFrameworkCore;
using CategoriesService.Models;

namespace CategoriesService.Data
{
    public class CategoriesDbContext : DbContext
    {
        public CategoriesDbContext(DbContextOptions<CategoriesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
    }
}
