using Feedbacks.Model.Category;
using Feedbacks.Repository;
using Feedbacks.Repository.Interface;
using Feedbacks.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Feedbacks.Service
{
    public class CategoryService: ICategoryService
    {
        private readonly ICategoryRepository _CategoryRepository;

        /// <summary>
        /// Category service
        /// </summary>
        /// <param name="CategoryRepository"></param>
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _CategoryRepository = categoryRepository;
        }

        public async Task<GetCategoryResponse> GetAllCategories()
        {
            try
            {
                var response = await _CategoryRepository.GetAllCategories();
                return response;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PostCategoryResponse> PostCategory(string categoryName)
        {
            try
            {
                var response = await _CategoryRepository.PostCategory(categoryName);
                return response;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UpdateCategoryResponse> UpdateCategory(Category category)
        {
            try
            {
                var response = await _CategoryRepository.UpdateCategory(category);
                return response;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PostCategoryResponse> DeleteCategoryById(int categoryId)
        {
            try
            {
                var response = await _CategoryRepository.DeleteCategoryById(categoryId);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
