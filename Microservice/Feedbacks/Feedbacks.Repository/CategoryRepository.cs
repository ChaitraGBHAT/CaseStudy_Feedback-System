using Feedbacks.Model.Category;
using Feedbacks.Repository.Context;
using Feedbacks.Repository.Interface;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feedbacks.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IConfiguration _configuration;
        private readonly DapperContext _context;

        public CategoryRepository(IConfiguration configuration, DapperContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public async Task<GetCategoryResponse> GetAllCategories()
        {
            try
            {
                var response = new GetCategoryResponse();
                string query = "Select * from Category";
                using (var connection = _context.CreateConnection())
                {
                    var categoryList = await connection.QueryAsync<Category>(query, null);
                    response.Result = categoryList.ToList();
                    return response;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PostCategoryResponse> PostCategory(string categoryName)
        {
            try
            {
                var response = new PostCategoryResponse();
                string query = "Insert into [dbo].[Category](CategoryName) Values(@CategoryName); SELECT CAST(SCOPE_IDENTITY() as int);";
                using (var connection = _context.CreateConnection())
                {
                    response.CategoryId = await connection.QueryFirstOrDefaultAsync<int>(query, new { CategoryName = categoryName});
                     if(response.CategoryId > 0)
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

        public async Task<UpdateCategoryResponse> UpdateCategory(Category category)
        {
            try
            {
                var response = new UpdateCategoryResponse();
                response.category = new Category();
                var query = @"UPDATE [dbo].[Category] SET CategoryName=@CategoryName WHERE CategoryId=@CategoryId; Select * from [dbo].[Category] where CategoryId=@CategoryId";

                using (var connection = _context.CreateConnection())
                {
                    response.category = await connection.QueryFirstOrDefaultAsync<Category>(query, new {  CategoryId = category.CategoryId, CategoryName = category.CategoryName });
                    if(response.category != null)
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

        public async Task<PostCategoryResponse> DeleteCategoryById(int categoryId)
        {
            try
            {
                var response = new PostCategoryResponse();
                using (var connection = _context.CreateConnection())
                {
                    string checkQuery = "SELECT CategoryId FROM [dbo].[Category] where CategoryId=@CategoryId";
                    var isExist = await connection.QueryFirstOrDefaultAsync<bool>(checkQuery, new { CategoryId = categoryId });
                    string query = "DELETE FROM [dbo].[Category] where CategoryId=@CategoryId";
                    response.CategoryId = await connection.QueryFirstOrDefaultAsync<int>(query, new { CategoryId = categoryId });
                    if (isExist == false)
                    {
                        response.message = "Category Id does not exist";
                    }
                    else
                    {
                        if (response.CategoryId == 0)
                        {
                            response.CategoryId = categoryId;
                            response.message = "Deleted Successfully.";
                        }
                        else
                        {
                            response.message = "Failed to delete.";
                        }
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

