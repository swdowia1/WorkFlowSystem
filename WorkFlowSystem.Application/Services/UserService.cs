using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlowSystem.Application.Repositories;
using WorkFlowSystem.Domain.Entities;

namespace WorkFlowSystem.Application.Services
{
    public class UserService
    {
        private readonly IRepository<User> _repository;

        public UserService(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task AddUserAsync(User user)
        {
            await _repository.AddAsync(user);

            await _repository.SaveChangesAsync();
        }
    }
}
