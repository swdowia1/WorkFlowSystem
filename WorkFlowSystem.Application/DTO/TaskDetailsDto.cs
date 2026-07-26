using WorkFlowSystem.Domain.Enums;

namespace WorkFlowSystem.Application.DTO
{
    public class TaskDetailsDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int ProjectId { get; set; }

        public string ProjectName { get; set; } = string.Empty;

        public TaskProjectStatus Status { get; set; }

        public TaskPriority Priority { get; set; }

        public DateTime? DueDate { get; set; }

        public decimal TotalHours { get; set; }

        public int WorkLogsCount { get; set; }

        public bool IsOverdue { get; set; }

        public List<WorkLogDto> WorkLogs { get; set; } = [];
        public List<TagDto> Tags { get; set; } = [];
    }
}
