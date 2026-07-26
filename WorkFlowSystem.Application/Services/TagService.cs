using WorkFlowSystem.Application.Repositories;
using WorkFlowSystem.Domain.Entities;

namespace WorkFlowSystem.Application.Services
{
    public class TagService : IService
    {

        private readonly IRepository<Tag> _tagRepository;

       
        private readonly ILinkRepository<TaskTag> _taskTagRepository;



        public TagService(
            IRepository<Tag> tagRepository,
            ILinkRepository<TaskTag> taskTagRepository)
        {
            _tagRepository = tagRepository;
            _taskTagRepository = taskTagRepository;
        }

       
        public async Task<IEnumerable<Tag>> GetAllAsync()
        {

            return await _tagRepository.GetAllAsync();

        }






        public async Task AddToTaskAsync(
            int taskId,
            int tagId)
        {


            var exists =
                await _taskTagRepository.AnyAsync(x =>
                    x.TaskId == taskId &&
                    x.TagId == tagId);



            if (exists)
                return;



            var taskTag = new TaskTag
            {
                TaskId = taskId,
                TagId = tagId
            };



            await _taskTagRepository.AddAsync(taskTag);


        }






        public async Task RemoveFromTaskAsync(
            int taskId,
            int tagId)
        {


            var item =
                await _taskTagRepository
                    .FirstOrDefaultAsync(x =>
                        x.TaskId == taskId &&
                        x.TagId == tagId);



            if (item == null)
                return;



            await _taskTagRepository.DeleteAsync(item);


        }


    }
}
