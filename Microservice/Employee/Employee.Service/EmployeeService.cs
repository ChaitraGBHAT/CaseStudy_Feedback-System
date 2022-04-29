using Employee.Model.Employee;
using Employee.Repository.Interface;
using Employee.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Service
{
    public class EmployeeService: IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        /// <summary>
        /// Employee service
        /// </summary>
        /// <param name="EmployeeRepository"></param>
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<PostEmployeeResponse> PostEmployeeDetails(PostEmployeeRequest employeeRequest)
        {
            try
            {
                var response = await _employeeRepository.PostEmployeeDetails(employeeRequest);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GetEmployeeByIdResponse> GetEmployeeDetailsById(int empId)
        {
            try
            {
                var response = await _employeeRepository.GetEmployeeDetailsById(empId);
                return response;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PutEmpDetailsResponse> UpdateEmployeeDetailsById(int empId, Model.Employee.Employee employee)
        {
            try
            {
                var response = await _employeeRepository.UpdateEmployeeDetailsById(empId, employee);
                return response;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GetByProjectIdResponse> GetAllEmpByProjectId(string projectId)
        {
            try
            {
                var response = await _employeeRepository.GetAllEmpByProjectId(projectId);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
