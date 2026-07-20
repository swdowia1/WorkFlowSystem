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
        private readonly WorkLogService _workLogService;
        public List<TaskProjectDto> Tasks { get; set; } = [];

        public IndexModel(TaskService taskService, WorkLogService workLogService)
        {

            _TaskService = taskService;
            _workLogService = workLogService;
        }
        public async Task<IActionResult> OnPostAddWorkLogAsync(
 [FromBody] WorkLogDto request)
        {
            if (request.Hours <= 0)
            {
                return BadRequest("Nie wybrano czasu.");
            }

            if (string.IsNullOrWhiteSpace(request.Description))
            {
                return BadRequest("Opis jest wymagany.");
            }



            await _workLogService.AddAsync(request);

            return new JsonResult(new
            {
                success = true
            });
        }
        public async Task OnGet()
        {
      
            Tasks = await _TaskService.GetOpenTasksByProjectAsync();
        }
    }
}
