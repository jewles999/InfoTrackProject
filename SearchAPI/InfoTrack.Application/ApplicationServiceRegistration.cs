using FluentValidation;
using InfoTrack.Application.Validators;
using InfoTrack.Domain.InputModels;
using Microsoft.Extensions.DependencyInjection;

namespace InfoTrack.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IValidator<SearchInput>, InputValidator>();
            return services;
        }
    }
}
