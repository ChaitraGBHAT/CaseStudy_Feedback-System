using Employee.Repository;
using Employee.Service.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Service
{
    public static class Dependencies
    {
        public static IServiceCollection ConnectService(this IServiceCollection service)
        {
            service
                .ConnectRepository()
                .AddTransient<IEmployeeService, EmployeeService>();
            return service;
        }
    }
}
