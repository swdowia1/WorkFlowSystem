using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlowSystem.Application.Services;

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
            ttask.Status.Should().Be(Domain.Enums.TaskProjectStatus.InProgress,"brak zapisu");

        }
    }
}
