
using WorkFlowSystem.Application.DTO;
using WorkFlowSystem.Application.Repositories;
using WorkFlowSystem.Domain.Entities;
using WorkFlowSystem.Domain.Enums;

namespace WorkFlowSystem.Application.Services
{
    public class DashboardService : IService
    {
        private readonly IRepository<Project> _projectRepository;
        private readonly IRepository<TaskItem> _taskRepository;
        private readonly IRepository<WorkLog> _workLogRepository;

        public DashboardService(IRepository<Project> projectRepository, IRepository<TaskItem> taskRepository, IRepository<WorkLog> workLogRepository)
        {
            _projectRepository = projectRepository;
            _taskRepository = taskRepository;
            _workLogRepository = workLogRepository;
        }

        public async Task<DashboardDto> GetDashboardAsync()
        {
            var projects = await _projectRepository.GetAllAsync();

            var tasks = await _taskRepository.GetAllAsync();

            var workLogs = await _workLogRepository.GetAllAsync();

            return new DashboardDto
            {
                Projects = projects.Count,

                Tasks = tasks.Count,

                OpenTasks = tasks.Count(x => x.Status != TaskProjectStatus.Done),

                TotalHours = workLogs.Sum(x => x.Hours)
            };
        }
    }
}
