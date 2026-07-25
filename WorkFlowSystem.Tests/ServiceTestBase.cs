using Microsoft.Extensions.DependencyInjection;
using WorkFlowSystem.Application.Services;
using WorkFlowSystem.Infrastructure.Persistence;
using WorkFlowSystem.Tests.KLasy;

namespace WorkFlowSystem.Tests
{
    public abstract class ServiceTestBase<TService>
    where TService : class, IService
    {
        protected IServiceProvider provider { get; }
        protected ApplicationDbContext contextDB { get; }
        protected TService service { get; }

        protected ServiceTestBase()
        {
            provider = TestServiceProvider.Create();

            contextDB = provider.GetRequiredService<ApplicationDbContext>();
            service = provider.GetRequiredService<TService>();
        }
    }
}
