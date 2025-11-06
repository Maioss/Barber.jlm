using Infrastructure.Repositories;
using Infrastructure.Repositories.Interfaces;

namespace Barber.jlm.Configurations
{
    public static class ServiceConfiguration
    {

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IBookingRepository, BookingRepository>();
            return services;
        }
    }
}
