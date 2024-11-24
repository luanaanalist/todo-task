using Microsoft.Extensions.DependencyInjection;
using ToDoApp.Application.Implementations;
using ToDoApp.Application.Services;
using ToDoApp.Domain.Repositories;
using ToDoApp.Infrastructure.Data.Repositories;

namespace ToDoApp.IoC
{
    public static class DependencyInjectionConfig
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            Services(services);
            Repositories(services);
        }

        private static void Services(IServiceCollection services)
        {
            services.AddScoped<IItemTaskService, ItemTaskService>();
          
        }

        private static void Repositories(IServiceCollection services)
        {
            services.AddScoped<IItemTaskRepository, ItemTaskRepository>();           
        }
    }
}
