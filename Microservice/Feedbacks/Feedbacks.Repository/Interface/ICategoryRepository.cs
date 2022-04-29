using Feedbacks.Model.Category;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Feedbacks.Repository.Interface
{
    public interface ICategoryRepository
    {
        /// <summary>
        /// Get Category List
        /// </summary>
        /// <returns></returns>
        Task<GetCategoryResponse> GetAllCategories();

        /// <summary>
        /// Post Category
        /// </summary>
        /// <returns></returns>
        Task<PostCategoryResponse> PostCategory(string categoryName);

        /// <summary>
        /// Update Category
        /// </summary>
        /// <returns></returns>
        Task<UpdateCategoryResponse> UpdateCategory(Category category);

        /// <summary>
        /// Delete Category
        /// </summary>
        /// <returns></returns>
        Task<PostCategoryResponse> DeleteCategoryById(int categoryId);

    }
}
