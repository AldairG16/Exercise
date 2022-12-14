using FluentValidation;
using FluentValidation.AspNetCore;
using System.Text.Json.Serialization;

namespace ExerciseGuidelines.Data.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string  Name { get; set; }

        public string Description { get; set; }

        public int AgeRestriction { get; set; }

        public string Company { get; set; }

        public decimal Price { get; set; }
        public int ProductTypeID { get; set; }

        //Navigation Properties
        public virtual ProductType? ProductType { get; set; }

        

    }
}
