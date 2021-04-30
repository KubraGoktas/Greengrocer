using Greengrocer.Business.Abstract;
using Greengrocer.Business.Validations.Product;
using Greengrocer.Entity.DTO.Product;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Greengrocer.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }



        // GET: api/<ProductController>
        [HttpGet("ListProduct")]
        public async Task<ActionResult<IEnumerable<ProductListDto>>>  Get()
        {
            var productList =await  _productService.ProductList();
            if (productList != null)
            {
                return Ok(productList);
            }
            else
            {
                return BadRequest();
            }
        }

        // GET api/<ProductController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<ProductController>
        [HttpPost("AddProduct")]
        public async Task<ActionResult<string>> Post([FromBody] ProductAddDto productAdd)
        {

            var validator = new AddProductValidator(_productService);
            var validationResult = validator.Validate(productAdd);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);
            }


            var result = await _productService.AddProduct(productAdd);

            if (result>0)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

        // PUT api/<ProductController>/5
        [HttpPut("UpdateProduct/{id}")]
        public async Task<ActionResult<string>> Put(int id, [FromBody] ProductAddDto productUpdate)
        {
            var result = await _productService.UpdateProduct(id, productUpdate);
            if (result > 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("DeleteProduct/{id}")]
        public ActionResult Delete(int id)
        {
            var result = _productService.DeleteProduct(id);
            if (result > 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
