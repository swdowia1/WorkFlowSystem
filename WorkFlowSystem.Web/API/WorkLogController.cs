using Microsoft.AspNetCore.Mvc;
using WorkFlowSystem.Application.DTO;
using WorkFlowSystem.Application.Services;

namespace WorkFlowSystem.Web.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkLogController : ControllerBase
    {
        private readonly WorkLogService _workLogService;

        public WorkLogController(WorkLogService workLogService)
        {
            _workLogService = workLogService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(WorkLogDto dto)
        {
            await _workLogService.AddAsync(dto);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _workLogService.DeleteAsync(id);
            return Ok();
        }
    }
}
