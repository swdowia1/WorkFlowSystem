
using WorkFlowSystem.Application.Common;
using WorkFlowSystem.Application.DTO;
using WorkFlowSystem.Application.InterFaces;
using WorkFlowSystem.Application.Repositories;
using WorkFlowSystem.Domain.Entities;
using WorkFlowSystem.Domain.Enums;

namespace WorkFlowSystem.Application.Services
{
    public class LookupService : ILookupService
    {
        private readonly IRepository<Project> _projectRepository;

        public LookupService(IRepository<Project> projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<List<LookupDto>> GetProjectsAsync(int? selected = null)
        {
            var projects = await _projectRepository.GetAllAsync();

            return projects.Select(x => new LookupDto
            {
                Value = x.Id,
                Text = x.Name,
            
            }).ToList();
        }

        public List<LookupDto> GetTaskStatuses(TaskStatus? selected = null)
        {
            return EnumHelper.ToSelectList(selected);
        }

        public List<LookupDto> GetTaskPriorities(TaskPriority? selected = null)
        {
            return EnumHelper.ToSelectList(selected);
        }

        public List<LookupDto> GetTaskStatuses(TaskProjectStatus? selected = null)
        {
            return EnumHelper.ToSelectList(selected);
        }
    }
}
