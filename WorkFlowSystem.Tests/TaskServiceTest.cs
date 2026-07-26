using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlowSystem.Application.Services;
using WorkFlowSystem.Domain.Entities;
using WorkFlowSystem.Domain.Enums;
using WorkFlowSystem.Infrastructure.Persistence;
using WorkFlowSystem.Tests.KLasy;

namespace WorkFlowSystem.Tests
{
    public class TaskServiceTests : ServiceTestBase<TaskService>
    {
       
        public TaskServiceTests()
        {
          
            contextDB.Projects.AddRange(new List<Project>
            {
                new Project
                {
                    Name = "CRM",
                    Description = "System CRM"
                },
                new Project
                {
                    Name = "ERP",
                    Description = "System ERP"
                }
            });
            const int projectId = 1;
            contextDB.Tasks.AddRange(new List<TaskItem>
            {
                new TaskItem
                {
                    Title = "Task 1",
                    Description = "Task 1 description",
                    ProjectId = projectId,
                    Status = TaskProjectStatus.InProgress
                },
                new TaskItem
                {
                    Title = "Task 2",
                    Description = "Task 2 description",
                    ProjectId = projectId,
                    Status =TaskProjectStatus.Done
                }
            });
            contextDB.SaveChanges();
        }
       
        
    }
}
