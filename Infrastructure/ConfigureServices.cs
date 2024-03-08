using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Infrastructure.Common;

namespace Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<DataContext>(options =>
            {
                //var connectionString = configuration.GetConnectionString("EnglishCenterDB");
                var connectionString = @"server=localhost; port=3306; database=store_management; user=root; password=";
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), options => {
                    options.EnableStringComparisonTranslations();
                })
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
            services.AddScoped<IDataContext>(provider => provider.GetRequiredService<DataContext>());
            services.AddScoped<ISqlQuery, SqlQuery>();
            services.AddScoped<ISqlCommand, SqlCommand>();
            return services;
        }
    }
}
