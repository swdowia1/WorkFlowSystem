

namespace WorkFlowSystem.Domain.Entities
{
    public class TaskTag
    {
        public int TaskId { get; set; }

        public TaskItem Task { get; set; } = default!;

        public int TagId { get; set; }

        public Tag Tag { get; set; } = default!;
    }
}
