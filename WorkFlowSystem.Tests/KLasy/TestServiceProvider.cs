using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WorkFlowSystem.Application.Repositories;
using WorkFlowSystem.Infrastructure.Infra;
using WorkFlowSystem.Infrastructure.Persistence;
using WorkFlowSystem.Web.Helper;

namespace WorkFlowSystem.Tests.KLasy
{
    public static class TestServiceProvider
    {
        public static IServiceProvider Create()
        {
            var services = new ServiceCollection();


            // DbContext InMemory

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseInMemoryDatabase(
                    Guid.NewGuid().ToString());
            });



            // Repository

            services.AddScoped(typeof(IRepository<>),
                               typeof(Repository<>));



            // Services

            services.AddApplicationServices();


            return services.BuildServiceProvider();
        }
    }
}
