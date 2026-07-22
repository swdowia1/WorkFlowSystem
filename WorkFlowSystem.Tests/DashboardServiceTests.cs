using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlowSystem.Application.Services;
using WorkFlowSystem.Infrastructure.Persistence;
using WorkFlowSystem.Tests.KLasy;

namespace WorkFlowSystem.Tests
{
    public class DashboardServiceTests
    {
        private readonly IServiceProvider provider;
        private readonly ApplicationDbContext context;
        private readonly DashboardService service;
        public DashboardServiceTests()
        {
            provider = TestServiceProvider.Create();

            context = provider.GetRequiredService<ApplicationDbContext>();

            service = provider.GetRequiredService<DashboardService>();
            context.Projects.AddRange(new List<WorkFlowSystem.Domain.Entities.Project>
            {
                new WorkFlowSystem.Domain.Entities.Project
                {
                    Name = "CRM",
                    Description = "System CRM"
                },
                new WorkFlowSystem.Domain.Entities.Project
                {
                    Name = "ERP",
                    Description = "System ERP"
                }
            });
            context.SaveChanges();
        }
        [Fact]
        public async Task GetDashboard_Should_Return_Project_Count()
        {
            var dto = await service.GetDashboardAsync();
            dto.Projects.Should().Be(2);
        }

        
    }
}
