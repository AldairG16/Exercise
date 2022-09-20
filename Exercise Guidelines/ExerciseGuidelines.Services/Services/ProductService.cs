using ExerciseGuidelines.Data;
using ExerciseGuidelines.Data.Models;
using ExerciseGuidelines.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseGuidelines.Services.Services
{
    public class ProductService : IProductServices
    {
        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAll()
        {
            try
            {
                return await _context.Product.AsNoTracking().ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Product> Get(int Id)
        {
            try
            {
                var Toy = await _context.Product.FindAsync(Id);
                if (Toy == null)
                    throw new Exception($"Toy with {Id} was not found.");
                return Toy;
            }
            catch
            {
                throw;
            }
            
        }

        public async Task<List<Product>> AddToy(Product Toy)
        {
            try
            {
                _context.Product.Add(Toy);
                await _context.SaveChangesAsync();
                return await _context.Product.ToListAsync();
            }
            catch
            {
                throw;
            }
            
        }

        public async Task<List<Product>> UpdateToy(Product request)
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
        public async Task<bool> DeleteAsync(int Id)
        {
            try
            {
                var Toy = await _context.Product.FindAsync(Id);
                if (Toy == null)
                    throw new Exception($"Toy not found.");

                _context.Product.Remove(Toy);
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
