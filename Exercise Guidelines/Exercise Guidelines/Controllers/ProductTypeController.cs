using ExerciseGuidelines.Data;
using ExerciseGuidelines.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exercise_Guidelines.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        //TODO: Chgane this
        public async Task<ActionResult<List<Product>>> GetProductWithType(int Id)
        {
            var result = await _context.Product.Where(p => p.Id == Id).Include(x => x.ProductType).ToListAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ProductType>> AddType(ProductType productType)
        {
            var Type = await _context.Product.FindAsync(productType);
            if (Type is not null)
            {
                return BadRequest("Type already exist");
                
            }
            _context.Product.Add(Type);
            await _context.SaveChangesAsync();
            return Ok(Type);


        }
    }
}
