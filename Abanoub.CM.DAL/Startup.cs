using Abanoub.CM.DAL.Repositories.Interfaces;
using Abanoub.CM.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Abanoub.CM.DAL
{
    public static class Startup
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            return services;
 
        }
    }
}
