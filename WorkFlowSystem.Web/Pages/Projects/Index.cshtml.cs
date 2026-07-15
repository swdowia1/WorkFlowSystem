using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkFlowSystem.Application.Services;
using WorkFlowSystem.Domain.Entities;

namespace WorkFlowSystem.Web.Pages.Projects
{
    public class IndexModel : PageModel
    {
        private readonly ProjectService _service;

        public List<Project> Projects { get; set; } = [];

        public IndexModel(ProjectService service)
        {
            _service = service;
        }

        public async Task OnGetAsync()
        {
            Projects = await _service.GetProjectsAsync();
        }
    }
}
