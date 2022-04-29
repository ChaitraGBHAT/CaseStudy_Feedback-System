using Manager.Repository.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Repository
{
    public static class Dependencies
    {
        public static IServiceCollection ConnectRepository(this IServiceCollection service)
        {
            service.AddTransient<IManagerRepository, ManagerRepository>();
            return service;
        }
    }
}
