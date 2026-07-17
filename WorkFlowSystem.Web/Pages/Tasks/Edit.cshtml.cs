using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WorkFlowSystem.Application.DTO;
using WorkFlowSystem.Application.Services;
using WorkFlowSystem.Application.ViewModels;
using WorkFlowSystem.Domain.Enums;
using WorkFlowSystem.Web.Extensions;

namespace WorkFlowSystem.Web.Pages.Tasks
{
    public class EditModel : PageModel
    {
        private readonly TaskService _taskService;
        private readonly LookupService _lookupService;
        [BindProperty]
        public TaskFormViewModel Form { get; set; } = new();

        public int Id { get; set; }

        public List<SelectListItem> Projects { get; set; } = [];

        public List<SelectListItem> Statuses { get; set; } = [];

        public List<SelectListItem> Priorities { get; set; } = [];
        public EditModel(TaskService taskService, LookupService lookupService)
        {
            _taskService = taskService;
            _lookupService = lookupService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var task = await _taskService.GetAsync(id);

            if (task == null)
                return NotFound();

            Form.Task = task;
            Form.Priorities = _lookupService.GetEnumLookup<TaskPriority>();
            Form.Statuses = _lookupService.GetEnumLookup<TaskProjectStatus>();
            Form.Projects = await _lookupService.GetProjectsAsync();
         

            return Page();
        }
        private async Task LoadLookups()
        {
            Projects = (await _lookupService
                .GetProjectsAsync())
              
                  .ToSelectList(); 

            Statuses = _lookupService
                .GetEnumLookup<TaskProjectStatus>()
                .ToSelectList();

            Priorities = _lookupService
                .GetEnumLookup<TaskPriority>()
                .ToSelectList();
        }
    }
}
