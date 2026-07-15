using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkFlowSystem.Application.DTO;
using WorkFlowSystem.Application.Services;

namespace WorkFlowSystem.Web.Pages.Projects
{
    public class CreateModel : PageModel
    {
        private readonly ProjectService _projectService;
        [BindProperty]
        public ProjectDto Project { get; set; } = new();

        public CreateModel(ProjectService projectService)
        {
            _projectService = projectService;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
               
                return Page();
            }
            Project.UserId = 1; // Set the UserId to a default value (e.g., 1) for now
            await _projectService.AddProjectAsync(Project);

            return RedirectToPage("Index");
        }

        public void OnGet()
        {
        }
    }
}
