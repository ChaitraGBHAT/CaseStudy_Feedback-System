using Feedbacks.Model.Feedback;
using Feedbacks.Repository.Interface;
using Feedbacks.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Feedbacks.Service
{
    public class FeedbackService: IFeedbackService
    {
        private readonly IFeedbackRepository _FeedbackRepository;

        /// <summary>
        /// Feedback service
        /// </summary>
        /// <param name="questionsRepository"></param>
        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            _FeedbackRepository = feedbackRepository;
        }

        public async Task<PostFeedbackResponse> PostFeedback(int empId, PostFeedbackRequest feedbackRequest)
        {
            try
            {
                var response = await _FeedbackRepository.PostFeedback(empId, feedbackRequest);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GetFeedbackByEmpIdResponse> GetFeedbackByEmpId(int empId)
        {
            try
            {
                var response = await _FeedbackRepository.GetFeedbackByEmpId(empId);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
