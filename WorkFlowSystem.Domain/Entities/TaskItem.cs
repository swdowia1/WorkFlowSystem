

using WorkFlowSystem.Domain.Enums;


namespace WorkFlowSystem.Domain.Entities
{
    public class TaskItem : BaseEntity
    {
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public TaskProjectStatus Status { get; set; }

        public TaskPriority Priority { get; set; }

        public DateTime? DueDate { get; set; }

        public int ProjectId { get; set; }

        public Project Project { get; set; } = null!;
        public ICollection<WorkLog> WorkLogs { get; set; } = [];
    }
}
