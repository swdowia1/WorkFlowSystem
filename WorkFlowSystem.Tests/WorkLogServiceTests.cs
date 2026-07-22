using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlowSystem.Application.DTO;
using WorkFlowSystem.Application.Services;
using WorkFlowSystem.Domain.Entities;
using WorkFlowSystem.Infrastructure.Persistence;
using WorkFlowSystem.Tests.KLasy;

namespace WorkFlowSystem.Tests
{
    public class WorkLogServiceTests
    {
        private readonly IServiceProvider provider;
        private readonly ApplicationDbContext context;
        private readonly WorkLogService service;

        public WorkLogServiceTests()
        {
            provider = TestServiceProvider.Create();

            context = provider.GetRequiredService<ApplicationDbContext>();

            service = provider.GetRequiredService<WorkLogService>();
        }
        [Fact]
        public async Task AddAsync_Should_Save_WorkLog()
        {
         
            var project = new Project
            {
                Name = "CRM"
            };

            context.Projects.Add(project);
            await context.SaveChangesAsync();

            var task = new TaskItem
            {
                Title = "API",
                ProjectId = project.Id
            };

            context.Tasks.Add(task);
            await context.SaveChangesAsync();

            var dto = new WorkLogDto
            {
                TaskId = task.Id,
                Hours = 5,
                Description = "Implementacja API"
            };

            // Act
            var result = await service.AddAsync(dto);

            // Assert
            result.Id.Should().BeGreaterThan(0);

            var workLog = context.WorkLogs.Single();

            workLog.TaskItemId.Should().Be(task.Id);
            workLog.Hours.Should().Be(5);
            workLog.Description.Should().Be("Implementacja API");
        }

        [Fact]
        public async Task AddAsync_Should_Use_Empty_Description_When_Null()
        {
            // Arrange
           

            var project = new Project
            {
                Name = "CRM"
            };

            context.Projects.Add(project);
            await context.SaveChangesAsync();

            var task = new TaskItem
            {
                Title = "API",
                ProjectId = project.Id
            };

            context.Tasks.Add(task);
            await context.SaveChangesAsync();

            // Act
            await service.AddAsync(new WorkLogDto
            {
                TaskId = task.Id,
                Hours = 2,
                Description = null
            });

            // Assert
            var workLog = context.WorkLogs.Single();

            workLog.Description.Should().BeEmpty();
        }

        [Fact]
        public async Task DeleteAsync_Should_Remove_WorkLog()
        {
        

            var project = new Project
            {
                Name = "CRM"
            };

            context.Projects.Add(project);
            await context.SaveChangesAsync();

            var task = new TaskItem
            {
                Title = "API",
                ProjectId = project.Id
            };

            context.Tasks.Add(task);
            await context.SaveChangesAsync();

            var workLog = new WorkLog
            {
                TaskItemId = task.Id,
                Hours = 4,
                WorkDate = DateTime.UtcNow,
                Description = "Test"
            };

            context.WorkLogs.Add(workLog);
            await context.SaveChangesAsync();

            // Act
            await service.DeleteAsync(workLog.Id);

            // Assert
            context.WorkLogs.Should().BeEmpty();
        }
    }
}
