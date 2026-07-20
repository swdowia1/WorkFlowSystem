using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkFlowSystem.Application.DTO;
using WorkFlowSystem.Application.Services;
using WorkFlowSystem.Domain.Entities;

namespace WorkFlowSystem.Web.Pages
{
    public class IndexModel : PageModel
    {
      
         private readonly TaskService _TaskService;
 
        public List<TaskProjectDto> Tasks { get; set; } = [];

        public IndexModel( TaskService taskService)
        {
           
            _TaskService = taskService;
        }

        public async Task OnGet()
        {
      
            Tasks = await _TaskService.GetOpenTasksByProjectAsync();
        }
    }
}
