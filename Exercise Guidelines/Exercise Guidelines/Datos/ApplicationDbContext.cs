using Exercise_Guidelines.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercise_Guidelines.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().Property(P => P.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Product>().Property(P => P.Description).HasMaxLength(100);
            modelBuilder.Entity<Product>().Property(P => P.AgeRestriction);
            modelBuilder.Entity<Product>().Property(P => P.Company).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Product>().Property(P => P.Price).IsRequired().HasColumnType("decimal");

            base.OnModelCreating(modelBuilder);
        }
    }
}
