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
        Task<List<Product>> GetProductWithType(int Id);

        Task<ProductType> AddType(ProductType productType);
        

        
    }
}
