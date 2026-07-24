namespace WorkFlowSystem.Application.DTO
{
    public class KanbanProjectDto
    {
        public int ProjectId { get; set; }

        public string ProjectName { get; set; } = string.Empty;

        public List<KanbanTaskDto> Tasks { get; set; } = [];
    }
}
