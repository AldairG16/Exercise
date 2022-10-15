using ExerciseGuidelines.Data;
using ExerciseGuidelines.Data.Models;
using ExerciseGuidelines.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExerciseGuidelines.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            try
            {
                var x = await _context.Product.AsNoTracking().ToListAsync();
                return x;
            
            }
            catch
            {
                throw;
            }
        }

        public async Task<Product> GetAsync(int id)
        {
            try
            {
                var toy = await _context.Product.FindAsync(id);
                if (toy == null)
                    throw new Exception($"Toy with {id} was not found.");
                return toy;
            }
            catch
            {
                throw;
            }
            
        }

        public async Task<List<Product>> AddToyAsync(Product toy)
        {
            try
            {
                _context.Product.Add(toy);
                await _context.SaveChangesAsync();
                return await _context.Product.ToListAsync();
            }
            catch
            {
                throw;
            }
            
        }

        public async Task<List<Product>> UpdateToyAsync(Product request)
        {
            try
            {
                var dbToy = await _context.Product.FindAsync(request.Id);
                if (dbToy == null)
                    throw new Exception("Toy not found.");
                dbToy.Name = request.Name;
                dbToy.Description = request.Description;
                dbToy.AgeRestriction = request.AgeRestriction;
                dbToy.Company = request.Company;
                dbToy.Price = request.Price;

                await _context.SaveChangesAsync();
                return await _context.Product.ToListAsync();
            }
            catch
            {
                throw;
            }
            
        }
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var dbToy = await _context.Product.FindAsync(id);
                if (dbToy == null)
                    throw new Exception($"Toy not found.");

                _context.Product.Remove(dbToy);
                await _context.SaveChangesAsync();
                return true;
            }

            catch
            {
                return false;
                throw;
            }

        }
        
    }
}
