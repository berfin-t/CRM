using CRM.Api.Application.Interfaces.Repositories;
using CRM.Api.Persistence.Context;
using CRM.Api.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Api.Persistence.Extensions;

public static class Registration
{
    public static IServiceCollection AddInfrastructureRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CRMDbContext>(conf =>
        {
            var connStr = configuration["CRMDbConnectionString"].ToString();
            conf.UseNpgsql(connStr, opt =>
            {
                opt.EnableRetryOnFailure();
            });
        });

        //var seedData = new SeedData();
        //seedData.SeedAsync(configuration).GetAwaiter().GetResult();

        services.AddScoped<IContactInfoRepository, ContactInfoRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<ICustomerTaskRepository, CustomerTaskRepository>();
        services.AddScoped<IInteractionRepository, InteractionRepository>();
        services.AddScoped<ISalesOpporrtunityRepository, SalesOpportunityRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;

        
    }
}
