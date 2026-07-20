using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlowSystem.Application.DTO;
using WorkFlowSystem.Application.Repositories;
using WorkFlowSystem.Domain.Entities;
using WorkFlowSystem.Domain.Enums;

namespace WorkFlowSystem.Application.Services
{
    public class TaskService : IService
    {
        private readonly IRepository<TaskItem> _repository;

        public TaskService(IRepository<TaskItem> repository)
        {
            _repository = repository;
        }
        public async Task<TaskItem?> GetDetailsAsync(int id)
        {
            return await _repository.GetAsync(
         id,
         x => x.Project,
         x => x.WorkLogs);
        }
        public async Task<List<TaskProjectDto>>
       GetOpenTasksByProjectAsync()
        {

            var tasks = await _repository.GetAllAsyncWhereInlude(

         x =>
             x.Status != TaskProjectStatus.Done,


         x => x.Project,
         x => x.WorkLogs
     );


            return tasks.Select(x => new TaskProjectDto
            {

                TaskId = x.Id,

                TaskTitle = x.Title,

                ProjectId = x.ProjectId,

                ProjectName = x.Project.Name,

                Status = x.Status,

                Priority = x.Priority,

                DueDate = x.DueDate,


                TotalHours =
                    x.WorkLogs.Sum(w => w.Hours)


            }).ToList();

        }
        public async Task<List<TaskItem>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        public async Task<List<TaskItem>> GetListAsync()
        {
            return await _repository.GetAllAsync(x => x.Project);
        }
        public async Task<TaskDto?> GetAsync(int id)
        {
            var task = await _repository.GetByIdAsync(id);

            if (task == null)
                return null;

            return new TaskDto
            {
                Title = task.Title,
                Description = task.Description,
                ProjectId = task.ProjectId,
                Status = task.Status,
                Priority = task.Priority,
                DueDate = task.DueDate
            };
        }
        public async Task UpdateAsync(int id, TaskDto dto)
        {
            var task = await _repository.GetByIdAsync(id);

            if (task == null)
                return;

            task.Title = dto.Title;
            task.Description = dto.Description;
            task.ProjectId = dto.ProjectId;
            task.Status = dto.Status;
            task.Priority = dto.Priority;
            task.DueDate = dto.DueDate;

            await _repository.UpdateAsync(task);

            await _repository.SaveChangesAsync();
        }
        public async Task AddAsync(TaskDto dto)
        {
            var task = new TaskItem
            {
                Title = dto.Title,
                Description = dto.Description,
                Status = dto.Status,
                Priority = dto.Priority,
                DueDate = dto.DueDate,
                ProjectId = dto.ProjectId
            };

            await _repository.AddAsync(task);
            await _repository.SaveChangesAsync();
        }
    }
}
