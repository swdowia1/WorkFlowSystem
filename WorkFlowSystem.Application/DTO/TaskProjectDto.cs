using WorkFlowSystem.Domain.Enums;

namespace WorkFlowSystem.Application.DTO
{
    public class TaskProjectDto
    {
        public int TaskId { get; set; }

        public string TaskTitle { get; set; } = string.Empty;

        public string ProjectName { get; set; } = string.Empty;

        public int ProjectId { get; set; }

        public TaskProjectStatus Status { get; set; }

        public TaskPriority Priority { get; set; }

        public DateTime? DueDate { get; set; }

        public decimal TotalHours { get; set; }
    }
}
