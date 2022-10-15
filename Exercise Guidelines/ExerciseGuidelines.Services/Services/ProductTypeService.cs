
using ExerciseGuidelines.Data;
using ExerciseGuidelines.Data.Models;
using ExerciseGuidelines.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExerciseGuidelines.Services
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly ApplicationDbContext _context;
        public ProductTypeService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> GetProductWithTypeAsync(int id)
        {
            try
            {
                var result = await _context.Product.Where(p => p.Id == id).Include(x => x.ProductType).ToListAsync();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<ProductType> AddTypeAsync(ProductType productType)
        {
            try
            {
                var type = await _context.Product.FindAsync(productType);
                if (type is not null)
                {
                    throw new("Type already exist");

                }
                _context.Product.Add(type);
                await _context.SaveChangesAsync();
                return (productType);
            }
            catch
            {
                throw;
            }
            
        }

       
    }
}