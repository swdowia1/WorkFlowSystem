using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkFlowSystem.Application.Services;
using WorkFlowSystem.Domain.Entities;

namespace WorkFlowSystem.Web.Pages.Tasks
{
    public class DetailsModel : PageModel
    {
        private readonly TaskService _taskService;
        public TaskItem? Task { get; private set; }
        public DetailsModel(TaskService taskService)
        {
            _taskService = taskService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Task = await _taskService.GetDetailsAsync(id);

            if (Task == null)
                return NotFound();

            return Page();
        }
    }
}
