using Employee.Repository.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Repository
{
    public static class Dependencies
    {
        public static IServiceCollection ConnectRepository(this IServiceCollection service)
        {
            service.AddTransient<IEmployeeRepository, EmployeeRepository>();
            return service;
        }
    }
}
