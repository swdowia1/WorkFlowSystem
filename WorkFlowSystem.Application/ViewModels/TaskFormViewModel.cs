using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlowSystem.Application.DTO;

namespace WorkFlowSystem.Application.ViewModels
{
    public class TaskFormViewModel
    {
        public TaskDto Task { get; set; } = new();
        public int Id { get; set; }
        public IEnumerable<LookupDto> Projects { get; set; } = [];

        public IEnumerable<LookupDto> Statuses { get; set; } = [];

        public IEnumerable<LookupDto> Priorities { get; set; } = [];
    }
}
