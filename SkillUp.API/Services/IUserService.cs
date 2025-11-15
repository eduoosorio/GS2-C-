using SkillUp.API.DTOs;

namespace SkillUp.API.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllAsync();
        Task<UserDTO?> GetByIdAsync(int id);
        Task<UserDTO> CreateAsync(CreateUserDTO createUserDTO);
        Task<UserDTO?> UpdateAsync(int id, UpdateUserDTO updateUserDTO);
        Task<bool> DeleteAsync(int id);
    }
}

