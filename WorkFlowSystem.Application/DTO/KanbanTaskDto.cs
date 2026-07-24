using WorkFlowSystem.Domain.Enums;

namespace WorkFlowSystem.Application.DTO
{
    public class KanbanTaskDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; }
        public TaskProjectStatus Status { get; set; }

        public TaskPriority Priority { get; set; }

        public int ProjectId { get; set; }

        public string ProjectName { get; set; } = string.Empty;
    }
}
