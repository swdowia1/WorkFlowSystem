using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkFlowSystem.Application.DTO;
using WorkFlowSystem.Application.DTO.Response;
using WorkFlowSystem.Application.Services;
using WorkFlowSystem.Domain.Entities;

namespace WorkFlowSystem.Web.Pages
{
    public class IndexModel : PageModel
    {
      
         private readonly TaskService _TaskService;
        private readonly WorkLogService _workLogService;
        //DashboardService
        private readonly DashboardService _DashboardService;
        public List<TaskProjectDto> Tasks { get; set; } = [];
        public DashboardDto Dashboard { get; set; }
        public IndexModel(TaskService taskService, WorkLogService workLogService, DashboardService dashboardService)
        {

            _TaskService = taskService;
            _workLogService = workLogService;
            _DashboardService = dashboardService;
        }
        public async Task<IActionResult> OnPostAddWorkLogAsync(
 [FromBody] WorkLogDto request)
        {
            if (request.Hours <= 0)
            {
                return BadRequest("Nie wybrano czasu.");
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
            Dashboard = await _DashboardService.GetDashboardAsync();
        }
    }
}
