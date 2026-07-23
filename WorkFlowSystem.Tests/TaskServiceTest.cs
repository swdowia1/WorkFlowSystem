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
    public class TaskServiceTests
    {
        private readonly IServiceProvider provider;
        private readonly ApplicationDbContext context;
        private readonly TaskService service;
        public TaskServiceTests()
        {
            provider = TestServiceProvider.Create();

            context = provider.GetRequiredService<ApplicationDbContext>();

            service = provider.GetRequiredService<TaskService>();
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
            context.SaveChanges();
        }
        [Fact]
        public async Task GetTaskDeatl()
        {
            var task = await service.GetDetailsAsync(1);
            task.Should().NotBeNull();
            task!.Title.Should().Be("Task 1");
            task.Project.Should().NotBeNull();
            task.Project.Name.Should().Be("CRM1");
        }
        
    }
}
