using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlowSystem.Domain.Enums;

namespace WorkFlowSystem.Application.Exceptions
{
    public class TaskNotFoundException : Exception
    {
        public int TaskId { get; }

        public TaskNotFoundException(int taskId)
            : base($"Task {taskId} nie istnieje.")
        {
            TaskId = taskId;
        }

    }
    public class TaskStatusChangeException : Exception
    {
        public int TaskId { get; }
        public TaskProjectStatus     Status { get; set; }

        public TaskStatusChangeException(int taskId, TaskProjectStatus status)
            : base($"Task {taskId} ma juz status {status.ToString()}")
        {
            TaskId = taskId;
        }

    }
}
