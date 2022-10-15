using ExerciseGuidelines.Data.Models;
using ExerciseGuidelines.Services.Interfaces;
using ExerciseGuidelines.Services.Validations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Exercise_Guidelines.Controller
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productServices;

        private IValidator<Product> _validator;

        public ProductController( IProductService productServices)
        {
            _productServices = productServices;
       
        }
       

        public ProductController(IValidator<Product> validator)
        {
            _validator = validator;
        }

        [HttpGet]
        //TODO producto
        public async Task<IActionResult> GetAll()
        {

            try
            {
                var products = await _productServices.GetAllAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var toy = await _productServices.GetAsync(id);
                if (toy == null)
                    return BadRequest("Toy not found.");
                return Ok(toy);
                
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            
                
            
        }
        [Route("addToy")]
        [HttpPost]
        public async Task<IActionResult> AddToy(Product toy)
        {
            try
            {
               return Ok(await _productServices.AddToyAsync(toy));
               
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            
        }

        [HttpPut]
        public async Task<IActionResult> UpdateToy(Product request)
        {
            try
            {
                return Ok(await _productServices.UpdateToyAsync(request));
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if ((await _productServices.DeleteAsync(id) == true))
                    return NoContent();
                return NotFound();
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Route("Validation")]
        [HttpPost]
        public async Task<IActionResult> PostValidation2(ProductValidation productValidator, [FromServices] IValidator<ProductValidation> validationRules)
        {
            var result = await validationRules.ValidateAsync(productValidator);
            if (!result.IsValid)
            {
                return BadRequest("NO SIRVE");
            }

            return Ok("Resultado valido");
        }

        
    }    
    
}      
