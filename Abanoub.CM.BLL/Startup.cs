using Microsoft.Extensions.DependencyInjection;
using Abanoub.CM.BLL.Services.Interfaces;
using Abanoub.CM.BLL.Services;
using Abanoub.CM.DAL;

namespace Abanoub.CM.BLL
{
    public static class Startup
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddRepositories();
            services.AddScoped<ICustomerService, CustomerService>();

            return services;
        }
    }
}
