using DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api
{
    public static class IocExtension
    {
        public  static void AddIoc(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddTransient<AppDbContext>();
        }
    }
}
