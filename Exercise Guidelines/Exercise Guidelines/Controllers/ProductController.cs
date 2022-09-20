
using ExerciseGuidelines.Data;
using ExerciseGuidelines.Data.Models;
using ExerciseGuidelines.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection.Metadata.Ecma335;

namespace Exercise_Guidelines.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _ProductServices;
        
        public ProductController( IProductServices ProductServices)
        {
            _ProductServices = ProductServices;
        }

        [HttpGet]
        //TODO: Chgane this
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _ProductServices.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            try
            {
                var Toy = await _ProductServices.Get(Id);
                if (Toy == null)
                    return BadRequest("Toy not found.");
                return Ok(Toy);
                
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            
                
            
        }

        [HttpPost]
        public async Task<IActionResult> AddToy(Product Toy)
        {
            try
            {
               return Ok(await _ProductServices.AddToy(Toy));
               
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
                return Ok(await _ProductServices.UpdateToy(request));
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                if ((await _ProductServices.DeleteAsync(Id) == true))
                    return NoContent();
                return NotFound();
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


    }    
    
}      
