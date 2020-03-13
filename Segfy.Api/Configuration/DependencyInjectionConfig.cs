using Microsoft.Extensions.DependencyInjection;
using Segfy.Core.Business.Interfaces.Arguments;
using Segfy.Core.Getway;
using Segfy.Core.Notifications;
using Segfy.Data.Persistence;
using Segfy.Data.Persistence.Repository;
using Segfy.Youtube.Interfaces;
using Segfy.Youtube.Services;

namespace Segfy.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<SegfyContext>();

            services.AddScoped<INotifier, Notifier>();
            services.AddScoped<IReader, Reader>();

            services.AddScoped<IYoutubeRepository, YoutubeRepository>();

            services.AddScoped<IYoutubeService, YoutubeService>();

            return services;
        }
    }
}