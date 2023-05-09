using InfoTrack.Application.Contracts.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace InfoTrack.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient<IWebSearcher, WebSearcher>();
            services.AddTransient<ISearchResultProcessor, SearchResultProcessor>();
            services.AddTransient<ISearchServiceProvider, SearchServiceProvider>();
            return services;
        }
    }
}
