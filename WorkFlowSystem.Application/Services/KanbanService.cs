using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlowSystem.Application.DTO;
using WorkFlowSystem.Application.Exceptions;
using WorkFlowSystem.Application.Repositories;
using WorkFlowSystem.Domain.Entities;
using WorkFlowSystem.Domain.Enums;

namespace WorkFlowSystem.Application.Services
{
    public class KanbanService:IService
    {
        private readonly IRepository<TaskItem> _repository;

        public KanbanService(IRepository<TaskItem> repository)
        {
            _repository = repository;
        }
        public async Task UpdateStatusAsync(UpdateTaskStatusDto dto)
        {
            var task = await _repository.GetAsync(dto.TaskId);

            if (task == null)
                throw new TaskNotFoundException(dto.TaskId);
            if (task.Status == (TaskProjectStatus)dto.Status)
                throw new TaskStatusChangeException(dto.TaskId, (TaskProjectStatus)dto.Status);

            task.Status = (TaskProjectStatus)dto.Status;

            await _repository.UpdateAsync(task);
            await _repository.SaveChangesAsync();
        }
        public async Task<List<KanbanProjectDto>> GetKanbanAsync()
        {

            var tasks = (await _repository.GetAllAsync(
         x => x.Project))
     .Select(x => new KanbanTaskDto
     {
         Id = x.Id,
         Title = x.Title,
         Status = x.Status,
         Priority = x.Priority,
         ProjectId = x.ProjectId,
         ProjectName = x.Project.Name
     })
     .ToList();


            return tasks
     .GroupBy(x => new
     {
         x.ProjectId,
         x.ProjectName
     })
     .Select(g => new KanbanProjectDto
     {
         ProjectId = g.Key.ProjectId,
         ProjectName = g.Key.ProjectName,
         Tasks = g.ToList()
     })
     .OrderBy(x => x.ProjectName)
     .ToList();

        }
    }
}
