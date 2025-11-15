using SkillUp.API.DTOs;

namespace SkillUp.API.Services
{
    public interface IUserSkillService
    {
        Task<IEnumerable<UserSkillDTO>> GetAllAsync();
        Task<UserSkillDTO?> GetByIdAsync(int id);
        Task<UserSkillDTO> CreateAsync(CreateUserSkillDTO createUserSkillDTO);
        Task<UserSkillDTO?> UpdateAsync(int id, UpdateUserSkillDTO updateUserSkillDTO);
        Task<bool> DeleteAsync(int id);
    }
}

