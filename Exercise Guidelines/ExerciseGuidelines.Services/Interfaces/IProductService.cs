using ExerciseGuidelines.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseGuidelines.Services.Interfaces
{
    public interface IProductServices
    {
        Task<List<Product>> GetAll();

        Task<Product> Get(int Id);

        Task<List<Product>> AddToy(Product Toy);

        Task<List<Product>> UpdateToy(Product request);

        Task<bool> DeleteAsync(int Id);



    }
}
