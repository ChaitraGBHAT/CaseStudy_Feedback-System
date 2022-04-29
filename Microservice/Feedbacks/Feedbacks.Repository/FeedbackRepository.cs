using Dapper;
using Feedbacks.Model.Feedback;
using Feedbacks.Repository.Context;
using Feedbacks.Repository.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feedbacks.Repository
{
    public class FeedbackRepository: IFeedbackRepository
    {
        private readonly IConfiguration _configuration;
        private readonly DapperContext _context;

        public FeedbackRepository(IConfiguration configuration, DapperContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public async Task<PostFeedbackResponse> PostFeedback(int empId, PostFeedbackRequest feedbackRequest)
        {
            try
            {
                var response = new PostFeedbackResponse();
                List<Feedback> feedbacks = new List<Feedback>();

                using (var connection = _context.CreateConnection())
                {
                    if (feedbackRequest.feedbacks.Count > 0)
                    {
                        foreach (var entity in feedbackRequest.feedbacks)
                        {
                            string query = @"Insert Into [dbo].[FeedBack](Feedbacks,Rating,EmpId,QuestionId) VALUES (@Feedbacks,@Rating,@EmpId,@QuestionId);SELECT * from [dbo].[Feedback] where FeedBackId = CAST(SCOPE_IDENTITY() as int)";
                            var feedbackList = await connection.QueryFirstOrDefaultAsync<Feedback>(query, new
                            {
                                Feedbacks = entity.Feedbacks,
                                Rating = entity.Rating,
                                EmpId = empId,
                                QuestionId = entity.QuestionId
                            });
                            feedbacks.Add(feedbackList);
                            string getQuery = "SELECT Question FROM [Questions] INNER JOIN Feedback ON Questions.QuestionId = Feedback.QuestionId where Questions.QuestionId=@QId";
                            var question = await connection.QueryFirstOrDefaultAsync<string>(getQuery, new
                            {
                                QId = entity.QuestionId
                            });
                            var insertQuery = "INSERT INTO [dbo].[Review](Question,Feedbacks,Rating,EmpId) VALUES (@Question,@Feedbacks,@Rating,@EmpId)";
                            var review = await connection.QueryFirstOrDefaultAsync<Review>(insertQuery, new
                            {
                                Question = question,
                                Feedbacks = entity.Feedbacks,
                                Rating = entity.Rating,
                                EmpId = empId
                            });
                        }
                        response.feedbacks = feedbacks;
                    }
                    if (response.feedbacks != null)
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

            public async Task<GetFeedbackByEmpIdResponse> GetFeedbackByEmpId(int empId)
            {
                try
                {
                    var response = new GetFeedbackByEmpIdResponse();
                    string query = "SELECT Question,Feedbacks,Rating FROM [dbo].[Review] where EmpId = @EmpId";
                    using (var connection = _context.CreateConnection())
                    {
                        var reviewList = await connection.QueryAsync<ReviewList>(query, new { EmpId = empId });
                        response.Review = reviewList.ToList();
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

