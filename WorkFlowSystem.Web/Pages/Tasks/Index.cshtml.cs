using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkFlowSystem.Application.Services;
using WorkFlowSystem.Domain.Entities;

namespace WorkFlowSystem.Web.Pages.Tasks
{
    public class IndexModel : PageModel
    {
        private readonly TaskService _service;

        public List<TaskItem> Tasks { get; set; } = [];

        public IndexModel(TaskService service)
        {
            _service = service;
        }

        public async Task OnGetAsync()
        {
           // Tasks = await _service.GetAllAsync();
            Tasks = await _service.GetListAsync();
        }
    }
}
