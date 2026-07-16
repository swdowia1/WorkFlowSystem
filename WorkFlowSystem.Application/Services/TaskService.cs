using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlowSystem.Application.DTO;
using WorkFlowSystem.Application.Repositories;
using WorkFlowSystem.Domain.Entities;

namespace WorkFlowSystem.Application.Services
{
    public class TaskService : IService
    {
        private readonly IRepository<TaskItem> _repository;

        public TaskService(IRepository<TaskItem> repository)
        {
            _repository = repository;
        }

        public async Task<List<TaskItem>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
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
