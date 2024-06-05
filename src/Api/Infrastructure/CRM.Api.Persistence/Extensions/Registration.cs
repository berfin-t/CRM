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
        services.AddDbContext<DbContext>(conf =>
        {
            var connStr = configuration["CRMDbConnectionString"].ToString();
            conf.UseNpgsql(connStr, opt =>
            {
                opt.EnableRetryOnFailure();
            });
        });

        return services;
    }
}
