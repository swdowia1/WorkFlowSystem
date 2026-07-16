using WorkFlowSystem.Application.DTO;
using WorkFlowSystem.Application.Repositories;
using WorkFlowSystem.Domain.Entities;

namespace WorkFlowSystem.Application.Services
{
    public class ProjectService : IService
    {
        private readonly IRepository<Project> _projectRepository;

        public ProjectService(IRepository<Project> projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<List<Project>> GetProjectsAsync()
        {
            return await _projectRepository.GetAllAsync();
        }

        public async Task AddProjectAsync(ProjectDto dto)
        {
            var project = new Project
            {
                Name = dto.Name,
                Description = dto.Description,
                UserId = dto.UserId
            };

            await _projectRepository.AddAsync(project);
            await _projectRepository.SaveChangesAsync();
        }
    }
}
