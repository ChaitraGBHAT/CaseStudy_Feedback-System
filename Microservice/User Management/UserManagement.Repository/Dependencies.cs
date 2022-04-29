using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Repository.Interface;

namespace UserManagement.Repository
{
    public static class Depenencies
    {
        public static IServiceCollection ConnectRepository(this IServiceCollection service)
        {
            service.AddTransient<IUserRepository, UserRepository>();
            return service;
        }
    }
}
