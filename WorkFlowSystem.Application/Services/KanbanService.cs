using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlowSystem.Application.DTO;
using WorkFlowSystem.Application.DTO.Response;
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
                throw new Exception($"Task {dto.TaskId} nie istnieje.");
            if(task.Status == (TaskProjectStatus)dto.Status)
                throw new Exception($"Task {dto.TaskId} już ma status {(TaskProjectStatus)dto.Status}.");

            task.Status = (TaskProjectStatus)dto.Status;

            await _repository.UpdateAsync(task);
        }
        public async Task<List<KanbanTaskDto>> GetKanbanAsync()
        {

            var tasks = await _repository.GetAllAsync();


            return tasks.Select(x => new KanbanTaskDto
            {
                Id = x.Id,

                Title = x.Title,

                Status = (int)x.Status,

                Priority = x.Priority.ToString()

            }).ToList();

        }
    }
}
