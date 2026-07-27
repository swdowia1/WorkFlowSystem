using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlowSystem.Application.DTO;
using WorkFlowSystem.Application.Exceptions;
using WorkFlowSystem.Application.Services;
using WorkFlowSystem.Domain.Enums;

namespace WorkFlowSystem.Tests
{
    public class KanbanServiceTest : ServiceTestBase<KanbanService>
    {
        [Fact]
        public async Task TaskSatusTest()
        {
             contextDB.Tasks.Add(new Domain.Entities.TaskItem   
            {
                Id = 1,
                Title = "Task 1",
                ProjectId = 1,
                Status = Domain.Enums.TaskProjectStatus.New

            });
            await contextDB.SaveChangesAsync();

            await service.UpdateStatusAsync(new Application.DTO.UpdateTaskStatusDto
            {
                TaskId = 1,
                Status = (int)Domain.Enums.TaskProjectStatus.Done
            });
            contextDB.ChangeTracker.Clear();
            var ttask = await contextDB.Tasks.FindAsync(1);
            ttask.Status.Should().Be(Domain.Enums.TaskProjectStatus.Done,"brak zapisu");

        }

        [Fact]
        public async Task UpdateStatusAsync_ShouldThrow_TaskStatusChangeException()
        {
            contextDB.Tasks.Add(new Domain.Entities.TaskItem
            {
                Id = 1,
                Title = "Task 1",
                ProjectId = 1,
                Status = Domain.Enums.TaskProjectStatus.Done

            });
            await contextDB.SaveChangesAsync();
            var dto = new UpdateTaskStatusDto
            {
                TaskId = 1,
                Status = (int)Domain.Enums.TaskProjectStatus.Done
            };
           
            var ex = await Assert.ThrowsAsync<TaskStatusChangeException>(() =>
                service.UpdateStatusAsync(dto));

        }
        [Fact]
        public async Task UpdateStatusAsync_ShouldThrow_WhenTaskDoesNotExist()
        {
            // Arrange
            var dto = new UpdateTaskStatusDto
            {
                TaskId = 999,
                Status = (int)TaskProjectStatus.Done
            };

            // Act
            var ex = await Assert.ThrowsAsync<TaskNotFoundException>(() =>
                service.UpdateStatusAsync(dto));

            // Assert
            
        }
    }
}
