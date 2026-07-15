

using WorkFlowSystem.Domain.Enums;
using TaskStatus = WorkFlowSystem.Domain.Enums.TaskStatus;

namespace WorkFlowSystem.Domain.Entities
{
    public class TaskItem : BaseEntity
    {
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public TaskStatus Status { get; set; }

        public TaskPriority Priority { get; set; }

        public DateTime? DueDate { get; set; }

        public int ProjectId { get; set; }

        public Project Project { get; set; } = null!;
    }
}
