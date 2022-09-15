using ExerciseGuidelines.Data;
using ExerciseGuidelines.Data.Models;
using ExerciseGuidelines.Services;
using ExerciseGuidelines.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exercise_Guidelines.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeService _productTypeService;

        public ProductTypeController(IProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;
        }

        [HttpGet]
        //TODO: Chgane this
        public async Task<ActionResult<List<Product>>> GetProductWithType(int Id)
        {
            try
            {
                var result = await _productTypeService.GetProductWithType(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //[HttpPost]
        //public async Task<ActionResult<ProductType>> AddType(ProductType productType)
        //{
        //    var Type = await _context.Product.FindAsync(productType);
        //    if (Type is not null)
        //    {
        //        return BadRequest("Type already exist");
                
        //    }
        //    _context.Product.Add(Type);
        //    await _context.SaveChangesAsync();
        //    return Ok(Type);
        //}
    }
}
