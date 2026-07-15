

namespace WorkFlowSystem.Domain.Entities
{
    public class TaskItem : BaseEntity
    {
        public string Title { get; set; } = string.Empty;

        public bool IsCompleted { get; set; }

        public int ProjectId { get; set; }

        public Project Project { get; set; } = null!;

        public ICollection<WorkLog> WorkLogs { get; set; } = [];
    }
}
