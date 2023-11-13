using BuberDiner.Application.Authentication.Command.Register;
using BuberDiner.Application.Authentication.Common;
using BuberDiner.Application.Common.Behaviors;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BuberDiner.Application.DependecyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplication( this IServiceCollection service)
        {
            service.AddMediatR(e => e.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            service.AddScoped(typeof(IPipelineBehavior<,>) , typeof(ValidationBehavior<,>));
            
            service.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
           
            return service;
        }

    }
}
