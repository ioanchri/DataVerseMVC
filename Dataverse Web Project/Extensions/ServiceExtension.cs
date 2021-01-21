using System;
using System.Collections.Generic;
using System.Text;
using Dataverse_Web_Project.Data;
using Dataverse_Web_Project.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Dataverse_Web_Project.Extensions
{
    public static class ServiceExtension
    {
        public static void AddCFServices(this IServiceCollection services)
        {
            services.AddDbContext<DataverseDBContext>(options => options.UseSqlServer(DataverseDBContext.connectionString));
            services.AddScoped<ICustomerService, CustomerService>();
           
        }
    }
}
