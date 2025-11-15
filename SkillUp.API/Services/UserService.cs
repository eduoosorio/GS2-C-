using AutoMapper;
using SkillUp.API.DTOs;
using SkillUp.API.Models;
using SkillUp.API.Repositories;

namespace SkillUp.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            var users = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public async Task<UserDTO?> GetByIdAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id);
            return user == null ? null : _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> CreateAsync(CreateUserDTO createUserDTO)
        {
            var user = _mapper.Map<User>(createUserDTO);
            var createdUser = await _repository.CreateAsync(user);
            return _mapper.Map<UserDTO>(createdUser);
        }

        public async Task<UserDTO?> UpdateAsync(int id, UpdateUserDTO updateUserDTO)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null)
                return null;

            _mapper.Map(updateUserDTO, user);
            var updatedUser = await _repository.UpdateAsync(user);
            return _mapper.Map<UserDTO>(updatedUser);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}

