using Microsoft.Extensions.DependencyInjection;
using Segfy.Data.Persistence;

namespace Segfy.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<SegfyContext>();
            //services.AddScoped<IYoutube, Youtube>();

            return services;
        }
    }
}