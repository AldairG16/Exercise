using ExerciseGuidelines.Data.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseGuidelines.Services.Validations
{
    public class ProductValidation : AbstractValidator<Product>
    {
        public ProductValidation()
        {
            RuleFor(model => model.Id).NotEmpty().WithMessage("Campo Requerido");
            RuleFor(model => model.Name).NotEmpty().WithMessage("Campo Requerido").MaximumLength(50).WithMessage("Maximo 50 caracteres");
            RuleFor(model => model.Description).MaximumLength(100).WithMessage("Maximo 100 caracteres");
            RuleFor(model => model.AgeRestriction).LessThan(0).WithMessage("Año minimo es 0").LessThanOrEqualTo(100).WithMessage("Año maximo es 100");
            RuleFor(model => model.Company).MaximumLength(50).WithMessage("Maximo 50 caracteres");
            RuleFor(model => model.Price).LessThan(0).WithMessage("Precio minimo es 0").LessThanOrEqualTo(1000).WithMessage("Precio maximo es 1000");
            RuleFor(model => model.ProductTypeID).NotEmpty().WithMessage("Campo Requerido");
        }
    }
}
