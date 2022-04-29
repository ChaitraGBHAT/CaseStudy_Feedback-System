using Feedbacks.Model.Questions;
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
    public class QuestionsController : ControllerBase
    {
        IQuestionsService _service;

        public QuestionsController(IQuestionsService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get Questions by category id
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetByCategoryId")]
        public async Task<IActionResult> GetQuestionsByCategoryId(int categoryId)
        {
            try
            {
                var result = await _service.GetQuestionsByCategoryId(categoryId);
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
        /// Post Questions
        /// </summary>
        /// <returns></returns>
        [HttpPost("PostQuestion")]
        public async Task<IActionResult> PostQuestion(int categoryId, string question)
        {
            try
            {
                var result = await _service.PostQuestion(categoryId, question);
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
        /// Update Question
        /// </summary>
        /// <returns></returns>
        [HttpPut("UpdateQuestion")]
        public async Task<IActionResult> UpdateQuestion(Questions question)
        {
            try
            {
                var result = await _service.UpdateQuestion(question);
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
        /// Delete Questions
        /// </summary>
        /// <returns></returns>
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteQuestionById(int questionId)
        {
            try
            {
                var result = await _service.DeleteQuestionById(questionId);
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
