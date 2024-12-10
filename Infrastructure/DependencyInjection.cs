using Application.Interfaces;
using Infrastructure.ExternalClients.Dictionary;
using Infrastructure.ExternalClients.Dictionary.Middlewares;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IAppDbContext>(provider => provider.GetRequiredService<AppDbContext>());

            // External services
            services.AddTransient<DictionaryServiceExceptionHandler>();
            services
                .AddRefitClient<IDictionaryApiService>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(configuration.GetValue<string>("DictionaryApiBaseUrl")!))
                .AddHttpMessageHandler<DictionaryServiceExceptionHandler>();

            return services;
        }
    }
}
