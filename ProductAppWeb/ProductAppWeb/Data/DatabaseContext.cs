using Microsoft.EntityFrameworkCore;
using ProductAppWeb.Models;

namespace ProductAppWeb.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {   
        }

        public DbSet<Product> Products { get; set; }
    }
}
