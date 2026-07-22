using System.ComponentModel.DataAnnotations;

namespace WorkFlowSystem.Application.DTO
{
    public class ProjectDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; } = string.Empty;

    }
}
