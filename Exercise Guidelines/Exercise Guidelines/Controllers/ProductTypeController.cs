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
        public async Task<ActionResult<List<ProductType>>> GetType(int Id)
        {
            _context.Product.Where(p => p.Id == Id).Include(x => x.ProductType);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<ProductType>> AddType(ProductType Id)
        {
            var Type = await _context.Product.FindAsync(Id);
            _context.Product.Add(Type);
            await _context.SaveChangesAsync();
            return Ok(await _context.Product.ToListAsync());
        }
    }
}
