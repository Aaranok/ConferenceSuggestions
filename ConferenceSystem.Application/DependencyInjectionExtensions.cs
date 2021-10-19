using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ConferencePlannerApp.Abstractions;
using Microsoft.EntityFrameworkCore;
using RatingSystem.Data;
using ConferenceSystem.Data;


namespace RatingSystem.Application
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection RegisterBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            //var connectionString = configuration.GetConnectionString("DefaultConnection");
            string connectionString = "Server = tcp:r7ddbsrv.database.windows.net,1433; Database = afterhills; User Id = r7dadmin; Password = B1llpwd!; MultipleActiveResultSets = true";
            services.AddDbContextPool<SuggestionsDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IConferenceRepository, ConferenceRepository>();

            return services;
        }
    }
}
