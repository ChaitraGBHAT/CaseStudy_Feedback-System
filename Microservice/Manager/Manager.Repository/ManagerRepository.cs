using Dapper;
using Manager.Model.Managers;
using Manager.Repository.Context;
using Manager.Repository.Interface;
using System;
using System.Threading.Tasks;

namespace Manager.Repository
{
    public class ManagerRepository: IManagerRepository
    {
        private readonly DapperContext _context;

        public ManagerRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<PostResponse> PostManagerDetails(PostRequest employeeRequest)
        {
            try
            {
                var response = new PostResponse();
                string query = "Insert into [dbo].[Manager](name,contactno,role,projectid,address) Values(@Name,@ContactNo,@Role,@ProjectId,@Address); SELECT CAST(SCOPE_IDENTITY() as int);";
                using (var connection = _context.CreateConnection())
                {
                    response.Id = await connection.QueryFirstOrDefaultAsync<int>(query, new
                    {
                        Name = employeeRequest.Name,
                        ContactNo = employeeRequest.Contactno,
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

        public async Task<GetDetailsByIdResponse> GetManagerDetailsById(int empId)
        {
            try
            {
                var response = new GetDetailsByIdResponse();
                string query = "SELECT * FROM [dbo].[Manager] WHERE Id=@EmpId";
                using (var connection = _context.CreateConnection())
                {
                    response.manager = await connection.QueryFirstOrDefaultAsync<Model.Managers.Manager>(query, new
                    {
                        EmpId = empId
                    });

                    return response;


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PutDetailsResponse> UpdateDetailsById(int empId, Manager.Model.Managers.Manager details)
        {
            try
            {
                var response = new PutDetailsResponse();
                response.manager = new Model.Managers.Manager();
                var query = @"UPDATE [dbo].[Manager] SET Name=@EmployeeName,Role=@RoleName,ProjectId=@ProjectId,Contactno=@Contactno,Address=@Address WHERE Id=@EmpId; Select * from [dbo].[Manager] where Id=@EmpId";

                using (var connection = _context.CreateConnection())
                {
                    response.manager = await connection.QueryFirstOrDefaultAsync<Model.Managers.Manager>(query, new
                    {
                        EmpId = empId,
                        EmployeeName = details.Name,
                        RoleName = details.Role,
                        ProjectId = details.Projectid,
                        Contactno = details.Contactno,
                        Address = details.Address
                    });
                    if (response.manager != null)
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
