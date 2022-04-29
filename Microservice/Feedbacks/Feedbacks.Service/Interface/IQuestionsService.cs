using Feedbacks.Model.Questions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Feedbacks.Service.Interface
{
    public interface IQuestionsService
    {
        Task<GetQuestionsByIdResponse> GetQuestionsByCategoryId(int categoryId);

        /// <summary>
        /// Delete Qustion
        /// </summary>
        /// <returns></returns>
        Task<DeleteQuestionResponse> DeleteQuestionById(int questionId);

        /// <summary>
        /// Post Question
        /// </summary>
        /// <returns></returns>
        Task<PostQuestionResponse> PostQuestion(int categoryId,string question);

        /// <summary>
        /// Update Question
        /// </summary>
        /// <returns></returns>
        Task<UpdateQuestionResponse> UpdateQuestion(Questions question);

    }
}
