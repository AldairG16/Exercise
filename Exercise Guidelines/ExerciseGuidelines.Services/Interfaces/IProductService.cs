using ExerciseGuidelines.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseGuidelines.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync();

        Task<Product> GetAsync(int Id);

        Task<List<Product>> AddToyAsync(Product Toy);

        Task<List<Product>> UpdateToyAsync(Product request);

        Task<bool> DeleteAsync(int Id);

     



    }
}
