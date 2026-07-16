using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WorkFlowSystem.Application.DTO;

using WorkFlowSystem.Application.Services;
using WorkFlowSystem.Domain.Enums;
using WorkFlowSystem.Web.Extensions;

namespace WorkFlowSystem.Web.Pages.Tasks
{
    public class CreateModel : PageModel
    {
        private readonly TaskService _taskService;
        private readonly LookupService _lookupService;

        public CreateModel(
            TaskService taskService,
            LookupService lookupService)
        {
            _taskService = taskService;
            _lookupService = lookupService;
        }

        [BindProperty]
        public TaskDto Task { get; set; } = new();

        public List<SelectListItem> Projects { get; set; } = [];

        public List<SelectListItem> Statuses { get; set; } = [];

        public List<SelectListItem> Priorities { get; set; } = [];

        public async Task OnGetAsync()
        {
            await LoadLookups();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await LoadLookups();
                return Page();
            }

            await _taskService.AddAsync(Task);

            return RedirectToPage("Index");
        }

        private async Task LoadLookups()
        {
             Projects = (await _lookupService.GetProjectsAsync()).ToSelectList();

            Statuses = _lookupService.GetEnumLookup<TaskProjectStatus>().ToSelectList();

            Priorities = _lookupService.GetEnumLookup<TaskPriority>().ToSelectList();
        }
    }
}
