using Employee.Model.Employee;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Repository.Interface
{
    public interface IEmployeeRepository
    {
        Task<PostEmployeeResponse> PostEmployeeDetails(PostEmployeeRequest employeeRequest);

        Task<GetEmployeeByIdResponse> GetEmployeeDetailsById(int empId);

        Task<PutEmpDetailsResponse> UpdateEmployeeDetailsById(int empId, Model.Employee.Employee employee);

        Task<GetByProjectIdResponse> GetAllEmpByProjectId(string projectId);
    }
}
