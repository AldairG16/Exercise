using ExerciseGuidelines.Data.Models;
using ExerciseGuidelines.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Exercise_Guidelines.Controllers
{
    [Route("api/productype")]
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
        public async Task<ActionResult<List<Product>>> GetProductWithType(int id)
        {
            try
            {
                var result = await _productTypeService.GetProductWithTypeAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddType(ProductType type)
        {
            try
            {
                var result = await _productTypeService.AddTypeAsync(type);
                if (result is null)
                {
                    return BadRequest("Type already exist");
                }

                return Ok(result);

                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        //[HttpPost]
        //public ActionResult Post([FromBody] ProductType productType)
        //{
        //    return Ok("Resultado valido");
        //}
    }
}
