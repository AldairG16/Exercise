
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
        public async Task<List<Product>> GetProductWithType(int Id)
        {
            try
            {
                var result = await _context.Product.Where(p => p.Id == Id).Include(x => x.ProductType).ToListAsync();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<ProductType> AddType(ProductType productType)
        {
            try
            {
                var Type = await _context.Product.FindAsync(productType);
                if (Type is not null)
                {
                    throw new("Type already exist");

                }
                _context.Product.Add(Type);
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