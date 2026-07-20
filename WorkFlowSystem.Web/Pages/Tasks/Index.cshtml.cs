using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkFlowSystem.Application.DTO;
using WorkFlowSystem.Application.Services;
using WorkFlowSystem.Domain.Entities;

namespace WorkFlowSystem.Web.Pages.Tasks
{
    public class IndexModel : PageModel
    {
        private readonly TaskService _service;
        private readonly WorkLogService _workLogService;

        public List<TaskItem> Tasks { get; set; } = [];

        public IndexModel(TaskService service, WorkLogService workLogService)
        {
            _service = service;
            _workLogService = workLogService;
        }

        public async Task OnGetAsync()
        {
           // Tasks = await _service.GetAllAsync();
            Tasks = await _service.GetListAsync();
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
    }
}
