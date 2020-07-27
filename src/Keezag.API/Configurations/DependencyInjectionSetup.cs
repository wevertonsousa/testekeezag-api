using Keezag.Domain.Context.Interfaces;
using Keezag.Domain.Context.Services;
using Keezag.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Keezag.API.Configurations
{
    public static class DependencyInjectionSetup
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();
        }
    }
}
