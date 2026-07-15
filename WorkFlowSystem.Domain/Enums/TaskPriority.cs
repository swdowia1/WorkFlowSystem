using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkFlowSystem.Domain.Enums
{
    public enum TaskPriority
    {
        [Description("Niski")]
        Low = 1,

        [Description("Średni")]
        Medium = 2,

        [Description("Wysoki")]
        High = 3,

        [Description("Krytyczny")]
        Critical = 4
    }
}
