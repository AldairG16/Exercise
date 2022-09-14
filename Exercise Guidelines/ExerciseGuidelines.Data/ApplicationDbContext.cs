using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ExerciseGuidelines.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ExerciseGuidelines.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //TODO: Add comment here
        }
        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Product
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().Property(P => P.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Product>().Property(P => P.Description).HasMaxLength(100);
            modelBuilder.Entity<Product>().Property(P => P.AgeRestriction);
            modelBuilder.Entity<Product>().Property(P => P.Company).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Product>().Property(P => P.Price).IsRequired().HasColumnType("decimal");

            //ProductType
            modelBuilder.Entity<ProductType>().HasKey(p => p.Id);
            modelBuilder.Entity<ProductType>().Property(p => p.Name).IsRequired().HasMaxLength(50);


            base.OnModelCreating(modelBuilder);

            //Relacion uno a muchos

            
                
                
                
        }
    }
}
