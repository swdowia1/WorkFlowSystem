using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WorkFlowSystem.Application.DTO;
using WorkFlowSystem.Application.Services;
using WorkFlowSystem.Domain.Entities;

namespace WorkFlowSystem.Web.Pages.Tasks
{
    public class DetailsModel : PageModel
    {
        private readonly TaskService _taskService;
        private readonly TagService _tagService;
        private readonly WorkLogService _workLogService;    
        public TaskDetailsDto Task { get; private set; }

        public List<Tag> Tags { get; private set; } = new();
        public DetailsModel(TaskService taskService, WorkLogService workLogService, TagService tagService)
        {
            _taskService = taskService;
            _workLogService = workLogService;
            _tagService = tagService;
        }
        public async Task<IActionResult> OnPostDeleteTagAsync(
    [FromBody] TaskTagDTO dto)
        {
            await _tagService.RemoveFromTaskAsync(dto.TaskId, dto.TagId);

            return new JsonResult(new
            {
                success = true
            });
        }
        public async Task<IActionResult> OnPostAddTagAsync(
    [FromBody] TaskTagDTO dto)
        {
            await _tagService.AddToTaskAsync(dto.TaskId, dto.TagId);

            return new JsonResult(new
            {
                success = true
            });
        }
        public async Task<IActionResult> OnPostDeleteWorkLogAsync(
    [FromBody] IntDto request)
        {
             await _workLogService.DeleteAsync(request.Id);

           

            return new JsonResult(new
            {
                success = true
            });
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
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Task = await _taskService.GetDetailsAsync2(id);
            Tags = (await _tagService.GetAllAsync()).ToList();
            if (Task == null)
                return NotFound();

            return Page();
        }
    }
}
