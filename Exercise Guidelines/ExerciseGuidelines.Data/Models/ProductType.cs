using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExerciseGuidelines.Data.Models
{
    public class ProductType
    {
        public int Id { get; set; }
        public string Name { get; set; }


        //Navigation Properties
        public virtual List<Product>? Products { get; set; }

        //public class ProductTypeValidator : AbstractValidator<ProductType>
        //{
        //    public ProductTypeValidator()
        //    {
        //        RuleFor(model => model.Id).NotEmpty().WithMessage("Campo Requerido");
        //        RuleFor(model => model.Name).MaximumLength(50).WithMessage("Maximo de caracteres es 50");
        //    }
        //}
    }
}
