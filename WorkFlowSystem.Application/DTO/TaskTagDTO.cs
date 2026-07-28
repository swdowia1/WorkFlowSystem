namespace WorkFlowSystem.Application.DTO
{
    /// <summary>
    /// dodaje tag do zadania lub usuwa go z zadania
    /// </summary>
    public class TaskTagDTO
    {
        public int TaskId { get; set; }

        public int TagId { get; set; }
    }
}
