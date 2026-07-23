using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlowSystem.Application.DTO.Response;
using WorkFlowSystem.Application.Repositories;
using WorkFlowSystem.Domain.Entities;

namespace WorkFlowSystem.Application.Services
{
    public class KanbanService:IService
    {
        private readonly IRepository<TaskItem> _repository;

        public KanbanService(IRepository<TaskItem> repository)
        {
            _repository = repository;
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
