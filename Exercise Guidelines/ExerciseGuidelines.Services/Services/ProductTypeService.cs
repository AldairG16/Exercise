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
            var result = await _context.Product.Where(p => p.Id == Id).Include(x => x.ProductType).ToListAsync();
            return result;
        }
    }
}