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
    public class UserService
    {
        private readonly IRepository<User> _repository;
        public async Task AddUserAsync(UserDto dto)
        {
            var user = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email
            };

            await _repository.AddAsync(user);
            await _repository.SaveChangesAsync();
        }
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
