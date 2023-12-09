using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Poliklinika.Application.Abstraction;
using System.Text;

namespace Poliklinika.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
           
            var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
            var dbName = Environment.GetEnvironmentVariable("DB_NAME");
            var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
            //var connectionsString= "Data Source=poliklinikadb;Initial Catalog=TestDB;User Id=SA;Password=pa@2or$%%dd;Persist Security Info=True;Encrypt=False";
            //var connectionsString = "Server=DESKTOP-HUHB6EP;Database = server21;Trusted_Connection=True;TrustServerCertificate=True;";


            var connectionsString = $"Data Source={dbHost};Initial Catalog={dbName};User ID=sa;Password={dbPassword};Persist Security Info=True;Connect Timeout = 30;Encrypt=False;TrustServerCertificate=True;Application Intent = ReadWrite;MultipleActiveResultSets=True;MultiSubnetFailover=True; Application Name=Ovit_Software;Pooling=True;";

            services.AddDbContext<IPoliklinikaDbContext, PoliklinikaDbContext>(options =>
            {
                options.UseSqlServer(connectionsString, providerOptions => providerOptions.EnableRetryOnFailure());
            });

            return services;
        }
    }
}
