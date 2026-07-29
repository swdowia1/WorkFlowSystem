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
    public class WorkLogServiceTests : ServiceTestBase<WorkLogService>
    {
       
        
        [Fact]
        public async Task AddAsync_Should_Save_WorkLog()
        {
         
            var project = new Project
            {
                Name = "CRM"
            };

            contextDB.Projects.Add(project);
            

            var task = new TaskItem
            {
                Title = "API",
                ProjectId = project.Id
            };

            contextDB.Tasks.Add(task);
            await SaveDB();

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

            var workLog = contextDB.WorkLogs.Single();

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

            contextDB.Projects.Add(project);
    

            var task = new TaskItem
            {
                Title = "API",
                ProjectId = project.Id
            };

            contextDB.Tasks.Add(task);

            await SaveDB();
            // Act
            await service.AddAsync(new WorkLogDto
            {
                TaskId = task.Id,
                Hours = 2,
                Description = null
            });

            // Assert
            var workLog = contextDB.WorkLogs.Single();

            workLog.Description.Should().BeEmpty();
        }

        [Fact]
        public async Task DeleteAsync_Should_Remove_WorkLog()
        {
        

            var project = new Project
            {
                Name = "CRM"
            };

            contextDB.Projects.Add(project);
          
            var task = new TaskItem
            {
                Title = "API",
                ProjectId = project.Id
            };

            contextDB.Tasks.Add(task);
          

            var workLog = new WorkLog
            {
                TaskItemId = task.Id,
                Hours = 4,
                WorkDate = DateTime.UtcNow,
                Description = "Test"
            };


            await SaveDB();

            // Act
            await service.DeleteAsync(workLog.Id);

            // Assert
            contextDB.WorkLogs.Should().BeEmpty();
        }
    }
}
