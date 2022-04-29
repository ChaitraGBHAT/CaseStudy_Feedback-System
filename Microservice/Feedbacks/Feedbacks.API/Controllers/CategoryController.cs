using Feedbacks.Model.Category;
using Feedbacks.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedbacks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get All Category List
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetCategory")]
        public async Task<IActionResult> GetAllCategoryList()
        {
            try
            {
                var result = await _service.GetAllCategories();
                if (result == null)
                {
                    return BadRequest(new { message = "Not Found" });

                }
                return Ok(result);

            }
            catch (Exception ex)
            {
                var result = new UnprocessableEntityObjectResult(ex.Message);
                return result;
            }
        }

        /// <summary>
        /// Post Category
        /// </summary>
        /// <returns></returns>
        [HttpPost("PostCategory")]
        public async Task<IActionResult> PostCategory(string categoryName)
        {
            try
            {
                var result = await _service.PostCategory(categoryName);
                if (result == null)
                {
                    return BadRequest(new { message = "Not Found" });

                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                var result = new UnprocessableEntityObjectResult(ex.Message);
                return result;
            }
        }

        /// <summary>
        /// Update Category
        /// </summary>
        /// <returns></returns>
        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(Category category)
        {
            try
            {
                var result = await _service.UpdateCategory(category);
                if (result == null)
                {
                    return BadRequest(new { message = "Not Found" });

                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                var result = new UnprocessableEntityObjectResult(ex.Message);
                return result;
            }
        }

        /// <summary>
        /// Delete Category
        /// </summary>
        /// <returns></returns>
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            try
            {
                var result = await _service.DeleteCategoryById(categoryId);
                if (result == null)
                {
                    return BadRequest(new { message = "Not Found" });

                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                var result = new UnprocessableEntityObjectResult(ex.Message);
                return result;
            }
        }
    }
}
