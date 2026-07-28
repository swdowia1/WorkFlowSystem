using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlowSystem.Application.Services;
using WorkFlowSystem.Domain.Entities;

namespace WorkFlowSystem.Tests
{
    public class TagServiceTest : ServiceTestBase<TagService>
    {
        [Fact]
        public async Task Add_Task_Tag_Test()
        {
            contextDB.Tasks.Add(new WorkFlowSystem.Domain.Entities.TaskItem
            {
                Title = "Task 1",
                Description = "Description 1"
            });
            contextDB.Tags.Add(new WorkFlowSystem.Domain.Entities.Tag
            {
                Name = "Tag 1"
            });
            await SaveDB();
            await service.AddTaskTagAsync(1, 1);
            var g = await contextDB.TaskTags
        .Include(x => x.Task)
        .Include(x => x.Tag)
        .FirstOrDefaultAsync();
            g.TaskId
               .Should()
               .Be(1);
        }
        [Fact]
        public async Task Remove_Task_Tag_Test()
        {
            contextDB.TaskTags.Add(new WorkFlowSystem.Domain.Entities.TaskTag
            {
                TaskId = 1,
                TagId = 1
            });
            await SaveDB();
            await service.RemoveTaskTagAsync(1, 1);
            var g = await contextDB.TaskTags.FirstOrDefaultAsync();
            g.Should().BeNull();
        }
        [Fact]
        public async Task Remove_NicNieusunie()
        {
            contextDB.TaskTags.Add(new WorkFlowSystem.Domain.Entities.TaskTag
            {
                TaskId = 2,
                TagId = 1
            });
            await SaveDB();
            await service.RemoveTaskTagAsync(1, 1);
            var g = await contextDB.TaskTags.FirstOrDefaultAsync();
            g.Should().NotBeNull();
        }
    }

}