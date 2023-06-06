using ListApi.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ListApi.DAL.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Notebook> Notebooks { get; set; }

        public DbSet<Line> Lines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SetupNotebooksConfiguration(modelBuilder);
            SetupLinesConfiguration(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private static void SetupNotebooksConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notebook>().HasKey(n => n.Id);
            modelBuilder.Entity<Notebook>().Property(n => n.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Notebook>().Property(n => n.Description).IsRequired().HasMaxLength(200);
        }

        private static void SetupLinesConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Line>().HasKey(n => n.Id);
            modelBuilder.Entity<Line>().Property(n => n.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Line>().Property(n => n.Description).IsRequired().HasMaxLength(200);
        }
    }
}
