using Manager.Repository;
using Manager.Service.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Service
{
    public static class Dependencies
    {
        public static IServiceCollection ConnectService(this IServiceCollection service)
        {
            service
                .ConnectRepository()
                .AddTransient<IManagerService, ManagerService>();
            return service;
        }
    }
}
