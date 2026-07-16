using System.Reflection;
using WorkFlowSystem.Application.Services;

namespace WorkFlowSystem.Web.Helper
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices2(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var types = assembly.GetTypes()
                .Where(t =>
                    t.IsClass &&
                    !t.IsAbstract &&
                    typeof(IService).IsAssignableFrom(t));

            foreach (var type in types)
            {
                services.AddScoped(type);
            }

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            var assembly = typeof(IService).Assembly;

            var types = assembly.GetTypes()
                .Where(t =>
                    t.IsClass &&
                    !t.IsAbstract &&
                    typeof(IService).IsAssignableFrom(t));

            foreach (var type in types)
            {
                services.AddScoped(type);
            }

            return services;
        }
    }
}
