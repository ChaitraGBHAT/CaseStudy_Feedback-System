using Feedbacks.Model.Questions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Feedbacks.Repository.Interface
{
    public interface IQuestionsRepository
    {
        Task<GetQuestionsByIdResponse> GetQuestionsByCategoryId(int categoryId);

        /// <summary>
        /// Post Question
        /// </summary>
        /// <returns></returns>
        Task<PostQuestionResponse> PostQuestion(int categoryId, string question);

        /// <summary>
        /// Delete Question
        /// </summary>
        /// <returns></returns>
        Task<DeleteQuestionResponse> DeleteQuestionById(int questionId);

        /// <summary>
        /// Update Question
        /// </summary>
        /// <returns></returns>
        Task<UpdateQuestionResponse> UpdateQuestion(Questions question);
    }
}
