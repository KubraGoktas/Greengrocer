using Greengrocer.Business.Abstract;
using Greengrocer.Entity.DTO.Category;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Greengrocer.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/<CategoryController>
        [HttpGet("GetCategoryList")]
        public async Task<ActionResult<IEnumerable<CategoryListDto>>> Get()
        {
            var categorylist = await _categoryService.CategoryList();
            if (categorylist != null)
            {
                return Ok(categorylist);
            }
            else
            {
                return BadRequest();
            }
        }

        // GET api/<CategoryController>/5
        [HttpGet("GetCategoryGetById/{id}")]
        public async Task<ActionResult<CategoryListDto>> Get(int id)
        {
            var category = await _categoryService.CategoryGetById(id);
            if (category != null)
            {
                return Ok(category);
            }
            else
            {
                return BadRequest();
            }
        }

        // POST api/<CategoryController>
        [HttpPost("CategoryAdd")]
        public async Task<ActionResult<string>> Post([FromBody] CategoryAddDto categoryAdd)
        {
            var result =await _categoryService.AddCategory(categoryAdd);
            if (result>0)
            {
                return Ok();
            }
            return BadRequest();
        }

        // PUT api/<CategoryController>/5
        [HttpPut("CategoryUpdate/{id}")]
        public async Task<ActionResult<string>> Put(int id, [FromBody] CategoryAddDto categoryUpdate)
        {
           var result= await _categoryService.UpdateCategory(id, categoryUpdate);
            if (result > 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("CategoryDelete/{id}")]
        public ActionResult Delete(int id)
        {
           var result= _categoryService.DeleteCategory(id);
            if (result>0)
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
