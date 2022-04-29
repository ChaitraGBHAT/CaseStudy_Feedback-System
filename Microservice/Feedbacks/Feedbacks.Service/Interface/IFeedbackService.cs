using Feedbacks.Model.Feedback;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Feedbacks.Service.Interface
{
    public interface IFeedbackService
    {
        Task<PostFeedbackResponse> PostFeedback(int empId, PostFeedbackRequest feedbackRequest);

        Task<GetFeedbackByEmpIdResponse> GetFeedbackByEmpId(int empId);
    }
}
