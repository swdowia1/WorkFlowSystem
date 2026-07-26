

namespace WorkFlowSystem.Domain.Entities
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string Color { get; set; } = "#3B82F6";

        public ICollection<TaskTag> TaskTags { get; set; } = [];
    }
}
