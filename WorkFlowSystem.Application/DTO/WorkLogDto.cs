namespace WorkFlowSystem.Application.DTO
{
    public class WorkLogDto
    {
        public int Id { get; set; }
        public int TaskId { get; set; }

        public decimal Hours { get; set; }

        public string Description { get; set; } = string.Empty;
    }
}
