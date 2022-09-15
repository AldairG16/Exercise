using ExerciseGuidelines.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseGuidelines.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(P => P.Name).IsRequired().HasMaxLength(50);
            builder.Property(P => P.Description).HasMaxLength(100);
            builder.Property(P => P.AgeRestriction);
            builder.Property(P => P.Company).IsRequired().HasMaxLength(50);
            builder.Property(P => P.Price).IsRequired().HasColumnType("decimal");
        }
    }
}
