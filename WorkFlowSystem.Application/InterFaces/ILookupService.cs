
using System.Web.Mvc;
using WorkFlowSystem.Application.DTO;
using WorkFlowSystem.Application.Services;
using WorkFlowSystem.Domain.Enums;

namespace WorkFlowSystem.Application.InterFaces
{
    public interface ILookupService 
    {
        Task<List<LookupDto>> GetProjectsAsync(int? selected = null);

        List<LookupDto> GetTaskStatuses(TaskProjectStatus? selected = null);

        List<LookupDto> GetTaskPriorities(TaskPriority? selected = null);
    }
}
