using Feedbacks.Repository.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Feedbacks.Repository
{
    public static class Dependencies
    {
        public static IServiceCollection ConnectRepository(this IServiceCollection service)
        {
            service.AddTransient<ICategoryRepository, CategoryRepository>();
             service.AddTransient<IQuestionsRepository, QuestionsRepository>();
            service.AddTransient<IFeedbackRepository, FeedbackRepository>();
            return service;
        }
    }
}
