using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkFlowSystem.Application.DTO.Response
{
    public class DashboardDto
    {
        public int Projects { get; set; }

        public int Tasks { get; set; }

        public int OpenTasks { get; set; }

        public decimal TotalHours { get; set; }
    }
}
