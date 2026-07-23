using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkFlowSystem.Application.DTO;
using WorkFlowSystem.Application.DTO.Response;
using WorkFlowSystem.Application.Services;

namespace WorkFlowSystem.Web.Pages.Tasks
{
    public class KanbanModel : PageModel
    {
        private readonly KanbanService _service;

        public KanbanModel(KanbanService service)
        {
            _service = service;
        }
        public async Task<IActionResult> OnPostUpdateStatusAsync(
    [FromBody] UpdateTaskStatusDto dto)
        {
            await _service.UpdateStatusAsync(dto);
            //cos
            return new JsonResult(new
            {
                success = true
            });
        }
        public List<KanbanTaskDto> Tasks { get; set; } = new();
        public async Task OnGetAsync()
        {
            Tasks = await _service.GetKanbanAsync();
        }
    }
}
