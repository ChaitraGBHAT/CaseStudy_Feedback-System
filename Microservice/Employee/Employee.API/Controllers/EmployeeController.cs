using Employee.Model.Employee;
using Employee.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        /// <summary>
        /// Post Employee Details
        /// </summary>
        /// <returns></returns>
        [HttpPost("PostEmployeeDetails")]
        public async Task<IActionResult> PostEmployeeDetails(PostEmployeeRequest employeeRequest)
        {
            try
            {
                var result = await _service.PostEmployeeDetails(employeeRequest);
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
        /// Get Employee Details By Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetEmployeeById")]
        public async Task<IActionResult> GetEmployeeDetailsById(int empId)
        {
            try
            {
                var result = await _service.GetEmployeeDetailsById(empId);
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
        /// Update Employee Details By Id
        /// </summary>
        /// <returns></returns>
        [HttpPut("UpdateEmployeeById")]
        public async Task<IActionResult> UpdateEmployeeDetailsById(int empId, Model.Employee.Employee employee)
        {
            try
            {
                var result = await _service.UpdateEmployeeDetailsById(empId, employee);
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
        /// Get All Employee By ProjectId
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllByProjectId")]
        public async Task<IActionResult> GetAllEmpByProjectId(string projectId)
        {
            try
            {
                var result = await _service.GetAllEmpByProjectId(projectId);
                if (result.employees == null)
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
