using BuberDiner.Api.Errors;
using BuberDiner.Api.Mapping;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BuberDiner.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<ProblemDetailsFactory, BuberDinnerProblemDetailsFactory>();
            services.AddMappings();
            return services;
        }

    }
}
