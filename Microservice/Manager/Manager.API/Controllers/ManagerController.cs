using Manager.Model.Managers;
using Manager.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        IManagerService _service;

        public ManagerController(IManagerService service)
        {
            _service = service;
        }

        /// <summary>
        /// Post Manager Details
        /// </summary>
        /// <returns></returns>
        [HttpPost("PostManagerDetails")]
        public async Task<IActionResult> PostManagerDetails(PostRequest managerRequest)
        {
            try
            {
                var result = await _service.PostManagerDetails(managerRequest);
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
        /// Get Manager Details By Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetDetailsById")]
        public async Task<IActionResult> GetManagerDetailsById(int empId)
        {
            try
            {
                var result = await _service.GetManagerDetailsById(empId);
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
        /// Update Manager Details By Id
        /// </summary>
        /// <returns></returns>
        [HttpPut("UpdateDetailsById")]
        public async Task<IActionResult> UpdateDetailsById(int empId, Model.Managers.Manager employee)
        {
            try
            {
                var result = await _service.UpdateDetailsById(empId, employee);
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
