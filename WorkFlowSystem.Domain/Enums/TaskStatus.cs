using System.ComponentModel;

namespace WorkFlowSystem.Domain.Enums
{
    public enum TaskStatus
    {
        [Description("Nowe")]
        New = 1,

        [Description("W trakcie")]
        InProgress = 2,

        [Description("Zakończone")]
        Done = 3,

        [Description("Anulowane")]
        Cancelled = 4
    }
}
