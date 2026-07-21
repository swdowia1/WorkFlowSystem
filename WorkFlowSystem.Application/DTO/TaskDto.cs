using System.ComponentModel.DataAnnotations;
using WorkFlowSystem.Domain.Enums;

namespace WorkFlowSystem.Application.DTO
{
    public class TaskDto
    {
        [Required]
        public string Title { get; set; } = "";

        public string? Description { get; set; } = "";

        public TaskProjectStatus Status { get; set; }

        public TaskPriority Priority { get; set; }


        public int ProjectId { get; set; }
    }
}
