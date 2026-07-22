using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlowSystem.Domain.Entities;
using WorkFlowSystem.Domain.Enums;

namespace WorkFlowSystem.Tests.KLasy
{
    public static class TestDataBuilder
    {
        public static Project Project(string name = "CRM")
        {
            return new Project
            {
                Name = name
            };
        }

        public static TaskItem Task(Project project)
        {
            return new TaskItem
            {
                Title = "API",
                Project = project,
                Status = TaskProjectStatus.New
            };
        }

        public static WorkLog WorkLog(TaskItem task)
        {
            return new WorkLog
            {
                TaskItem = task,
                Hours = 8,
                WorkDate = DateTime.Today
            };
        }
    }
}
