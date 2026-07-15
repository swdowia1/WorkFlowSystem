

namespace WorkFlowSystem.Domain.Entities
{
    public class WorkLog : BaseEntity
    {
        public DateTime WorkDate { get; set; }

        public decimal Hours { get; set; }

        public string Description { get; set; } = string.Empty;

        public int TaskItemId { get; set; }

        public TaskItem TaskItem { get; set; } = null!;
    }
}
