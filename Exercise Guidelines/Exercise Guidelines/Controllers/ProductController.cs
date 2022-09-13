using Exercise_Guidelines.Datos;
using Exercise_Guidelines.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection.Metadata.Ecma335;

namespace Exercise_Guidelines.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            return Ok(await _context.Product.ToListAsync());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Product>> Get(int Id)
        {
            var Toy = await _context.Product.FindAsync(Id);
            if (Toy == null)
                return BadRequest("Toy not found.");
            return Ok(Toy);
        }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> AddToy(Product Toy)
        {
            _context.Product.Add(Toy);
            await _context.SaveChangesAsync();
            return Ok(await _context.Product.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Product>>> UpdateToy(Product request)
        {
            var dbToy = await _context.Product.FindAsync(request.Id);
            if (dbToy == null)
                return BadRequest("Toy not found.");
            dbToy.Name = request.Name;
            dbToy.Description = request.Description;
            dbToy.AgeRestriction = request.AgeRestriction;
            dbToy.Company= request.Company;
            dbToy.Price = request.Price;

            await _context.SaveChangesAsync();
            return Ok(await _context.Product.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<Product>> Delete(int Id)
        {
            var Toy = await _context.Product.FindAsync(Id);
            if (Toy == null)
                return BadRequest("Toy not found.");
            
            _context.Product.Remove(Toy);
            await _context.SaveChangesAsync();
            return Ok(await _context.Product.ToListAsync());
        }


    }    
    
}      
