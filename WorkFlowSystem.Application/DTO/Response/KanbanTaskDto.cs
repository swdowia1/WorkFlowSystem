

namespace WorkFlowSystem.Application.DTO.Response
{
    public class KanbanTaskDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = "";

        public int Status { get; set; }

        public string Priority { get; set; } = "";
    }
}
