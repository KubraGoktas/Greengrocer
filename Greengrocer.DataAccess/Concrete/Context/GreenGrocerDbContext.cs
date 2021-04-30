using Greengrocer.Entity.Entity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Greengrocer.DataAccess.Concrete.Context
{
    public class GreenGrocerDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=127.0.0.1;Database=Greengrocer;Uid=root;Pwd=1234;convert zero datetime=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
