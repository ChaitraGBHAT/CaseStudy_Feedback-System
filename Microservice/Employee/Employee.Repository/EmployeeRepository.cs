using Dapper;
using Employee.Model.Employee;
using Employee.Repository.Context;
using Employee.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Repository
{
    public class EmployeeRepository: IEmployeeRepository
    {

        private readonly DapperContext _context;

        public EmployeeRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<PostEmployeeResponse> PostEmployeeDetails(PostEmployeeRequest employeeRequest)
        {
            try
            {
                var response = new PostEmployeeResponse();
                string query = "Insert into [dbo].[Employee](name,contactno,role,projectid,address) Values(@Name,@ContactNo,@Role,@ProjectId,@Address); SELECT CAST(SCOPE_IDENTITY() as int);";
                using (var connection = _context.CreateConnection())
                {
                    response.Id = await connection.QueryFirstOrDefaultAsync<int>(query, new { 
                        Name = employeeRequest.Name,
                        ContactNo =employeeRequest.Contactno,
                        Role = employeeRequest.Role,
                        ProjectId = employeeRequest.Projectid,
                        Address = employeeRequest.Address
                    });
                    if (response.Id > 0)
                    {
                        response.message = "Inserted Successfully.";
                    }
                    else
                    {
                        response.message = "Failed to insert.";
                    }
                    return response;


                }
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
                var response = new GetEmployeeByIdResponse();
                string query = "SELECT * FROM [dbo].[Employee] WHERE Id=@EmpId";
                using (var connection = _context.CreateConnection())
                {
                    response.employee = await connection.QueryFirstOrDefaultAsync<Model.Employee.Employee>(query, new
                    {
                       EmpId = empId
                    });
                   
                    return response;


                }
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
                var response = new PutEmpDetailsResponse();
                response.employee = new Model.Employee.Employee();
                var query = @"UPDATE [dbo].[Employee] SET Name=@EmployeeName,Role=@RoleName,ProjectId=@ProjectId,Contactno=@Contactno,Address=@Address WHERE Id=@EmpId; Select * from [dbo].[Employee] where Id=@EmpId";

                using (var connection = _context.CreateConnection())
                {
                    response.employee = await connection.QueryFirstOrDefaultAsync<Model.Employee.Employee>(query, new { 
                        EmpId = empId,
                        EmployeeName = employee.Name,
                        RoleName = employee.Role,
                        ProjectId = employee.Projectid,
                        Contactno = employee.Contactno,
                        Address = employee.Address
                    });
                    if (response.employee != null)
                    {
                        response.message = "Updated Successfully.";
                    }
                    else
                    {
                        response.message = "Failed to update.";
                    }
                    return response;

                }
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
                var response = new GetByProjectIdResponse();
                string query = "SELECT * FROM [dbo].[Employee] WHERE projectid=@ProjectId";
                using (var connection = _context.CreateConnection())
                {
                    var empList = await connection.QueryAsync<Model.Employee.Employee>(query, new
                    {
                        ProjectId = projectId
                    });
                    response.employees = empList.ToList();
                    return response;


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
