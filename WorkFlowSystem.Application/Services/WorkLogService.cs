using WorkFlowSystem.Application.DTO;
using WorkFlowSystem.Application.FUN;
using WorkFlowSystem.Application.Repositories;
using WorkFlowSystem.Domain.Entities;

namespace WorkFlowSystem.Application.Services
{
    public class WorkLogService:IService
    {
        private readonly IRepository<WorkLog> _repository;

        public WorkLogService(IRepository<WorkLog> repository)
        {
            _repository = repository;
        }

        public async Task<WorkLogDto> AddAsync(WorkLogDto dto)
        {
            var entity = new WorkLog
            {
                TaskItemId = dto.TaskId,
                WorkDate = classFun.DateNowUTC(),
                Hours = dto.Hours,
                Description = dto.Description??"".Trim()
            };

            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();

            dto.Id = entity.Id;

            return dto;
        }

       

        public async Task DeleteAsync(int id)
        {
           

            await _repository.DeleteAsync(id);

            await _repository.SaveChangesAsync();
        }
    }
}
