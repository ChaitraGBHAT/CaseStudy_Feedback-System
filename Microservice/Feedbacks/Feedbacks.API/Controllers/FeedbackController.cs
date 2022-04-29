using Feedbacks.Model.Feedback;
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
    public class FeedbackController : ControllerBase
    {

        IFeedbackService _service;

        public FeedbackController(IFeedbackService service)
        {
            _service = service;
        }

        /// <summary>
        /// Post Feedback
        /// </summary>
        /// <returns></returns>
        [HttpPost("PostFeedback")]
        public async Task<IActionResult> PostFeedback(int empId, PostFeedbackRequest feedbackRequest)
        {
            try
            {
                var result = await _service.PostFeedback(empId, feedbackRequest);
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
        /// Get Feedbacks by employee id
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetFeedbackByEmpId")]
        public async Task<IActionResult> GetFeedbackByEmpId(int empId)
        {
            try
            {
                var result = await _service.GetFeedbackByEmpId(empId);
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
