

namespace WorkFlowSystem.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime UpdatedAtUtc { get; set; }
    }
}
