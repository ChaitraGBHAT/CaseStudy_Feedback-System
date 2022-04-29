using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Repository;
using UserManagement.Service.Interface;

namespace UserManagement.Service
{
    public static class Depenencies
    {
        public static IServiceCollection ConnectService(this IServiceCollection service)
        {
            service
                .ConnectRepository()
                .AddTransient<IUserService, UserService>();
            return service;
        }
    }
}
