using ExerciseGuidelines.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseGuidelines.Services.Interfaces
{
    public interface IProductTypeService
    {
        Task<List<Product>> GetProductWithTypeAsync(int Id);

        Task<ProductType> AddTypeAsync(ProductType productType);
        

        
    }
}
