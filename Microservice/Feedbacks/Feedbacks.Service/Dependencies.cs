using Feedbacks.Repository;
using Feedbacks.Service.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Feedbacks.Service
{
    public static class Dependencies
    {
        public static IServiceCollection ConnectService(this IServiceCollection service)
        {
            service
                .ConnectRepository()
                .AddTransient<ICategoryService, CategoryService>()
                .AddTransient<IQuestionsService, QuestionsService>()
                .AddTransient<IFeedbackService, FeedbackService>();
            return service;
        }
    }
}
