using IngswDev.EntityFramework.Managers.Entities;
using IngswDev.EntityFramework.Managers.Scopes;
using IngswDev.EntityFramework.Managers.Security;
using IngswDev.EntityFramework.Repository.Entities;
using IngswDev.EntityFramework.Repository.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IngswDev.EntityFramework
{
    public static class IngswDevExtension
    {
        public static IServiceCollection AddIngswDevContext(this IServiceCollection services, IConfigurationRoot configuration)
        {
            var connString = configuration["Data:IngswDevDB"];
            services.AddEntityFramework()
                .AddDbContext<IngswDevDB>(opt =>
                {
                    opt.UseSqlServer(connString);
                });
            // Add IngsDev Repositories
            services.UseRepositoryPattern();
            // Add IngswDev Managers
            services.AddManagers();
            return services;
        }

        public static IServiceCollection UseRepositoryPattern(this IServiceCollection services)
        {
            services.AddScoped<UserRepo>();
            services.AddScoped<TokenRepo>();
            services.AddScoped<EventRepo>();
            services.AddScoped<EventDateRepo>();
            return services;
        }

        public static IServiceCollection AddManagers(this IServiceCollection services)
        {
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<IEventManager, EventManager>();
            return services;
        }
    }
}
