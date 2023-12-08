using Kadastr.Application.Abstraction;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Kadastr.Infrastructure
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


            var connectionsString = $"Data Source={dbHost};Initial Catalog={dbName};User ID=sa;Password={dbPassword};Encrypt=False;Connection Timeout=120";

            services.AddDbContext<IKadastrDbContext, KadastrDbContext>(options =>
            {
                options.UseSqlServer(connectionsString, providerOptions => providerOptions.EnableRetryOnFailure());
            });

            return services;
        }
    }
}
