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
            const int projectId = 1;
            context.Tasks.AddRange(new List<WorkFlowSystem.Domain.Entities.TaskItem>
            {
                new WorkFlowSystem.Domain.Entities.TaskItem
                {
                    Title = "Task 1",
                    Description = "Task 1 description",
                    ProjectId = projectId,
                    Status = WorkFlowSystem.Domain.Enums.TaskProjectStatus.InProgress
                },
                new WorkFlowSystem.Domain.Entities.TaskItem
                {
                    Title = "Task 2",
                    Description = "Task 2 description",
                    ProjectId = projectId,
                    Status = WorkFlowSystem.Domain.Enums.TaskProjectStatus.Done
                }
            });
            context.WorkLogs.AddRange(new List<WorkFlowSystem.Domain.Entities.WorkLog>
            {
                new WorkFlowSystem.Domain.Entities.WorkLog
                {
                    TaskItemId = 1,
                    Hours = 3
                },
                new WorkFlowSystem.Domain.Entities.WorkLog
                {
                    TaskItemId = 2,
                    Hours = 2
                }
            }); 
            context.SaveChanges();
        }
        [Fact]
        public async Task GetDashboard_Should_Return_Project_Count()
        {
            var dto = await service.GetDashboardAsync();
            dto.Projects.Should().Be(2);
            dto.Tasks.Should().Be(2);
            dto.OpenTasks.Should().Be(1);
            dto.TotalHours.Should().Be(5);
        }

        
    }
}
